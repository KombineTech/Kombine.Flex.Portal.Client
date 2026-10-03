import io
from pathlib import Path
from types import SimpleNamespace
import unittest
from unittest.mock import Mock, patch
import urllib.error
import zipfile
import publish as release


def archive(content=b'library', signed=False):
    stream = io.BytesIO()
    with zipfile.ZipFile(stream, 'w') as package:
        package.writestr('lib/net8.0/client.dll', content)
        if signed:
            package.writestr('.signature.p7s', b'nuget-signature')
    return stream.getvalue()


class PublishingTests(unittest.TestCase):
    def setUp(self):
        self.environment = {'GITHUB_REPOSITORY': release.REPOSITORY,
                            'GITHUB_EVENT_NAME': 'push', 'GITHUB_REF': 'refs/heads/main',
                            'NUGET_API_KEY': 'synthetic-key'}

    def test_main_only(self):
        release.require_main(self.environment)
        for field, value in [('GITHUB_REF', 'refs/heads/feature'), ('GITHUB_REF', 'refs/tags/v1.0.0'),
                             ('GITHUB_EVENT_NAME', 'pull_request'), ('GITHUB_REPOSITORY', 'someone/fork')]:
            with self.subTest(field=field, value=value), self.assertRaises(ValueError):
                release.require_main(dict(self.environment, **{field: value}))

    def test_version_change_is_numeric_and_strict(self):
        self.assertFalse(release.increased('0.3.1', '0.3.1'))
        self.assertTrue(release.increased('0.3.9', '0.3.10'))
        self.assertTrue(release.increased('0.9.9', '1.0.0'))
        with self.assertRaises(ValueError):
            release.increased('1.0.0', '0.9.9')

    def test_identity_rejects_arbitrary_packages_and_versions(self):
        for name, version in [('Other', '1.0.0'), (release.PACKAGE, '1.0.0-beta'),
                              (release.PACKAGE, '01.0.0'), (release.PACKAGE, '$(Version)')]:
            with self.subTest(name=name, version=version), self.assertRaises(ValueError):
                release.identity(f'<Project><PropertyGroup><PackageId>{name}</PackageId><Version>{version}</Version></PropertyGroup></Project>')

    def test_plan_compares_the_previous_main_tip(self):
        current = (release.ROOT / release.PROJECT).read_bytes()
        version = release.identity(current)
        runner = Mock(return_value=current)
        self.assertEqual((version, False), release.plan({'before': 'a' * 40}, self.environment, runner))
        runner.assert_called_once_with(['git', 'show', f'{"a" * 40}:{release.PROJECT}'], cwd=release.ROOT)
        earlier = current.replace(f'<Version>{version}</Version>'.encode(), b'<Version>0.0.0</Version>')
        self.assertEqual((version, True), release.plan({'before': 'b' * 40}, self.environment, Mock(return_value=earlier)))

    def test_missing_or_invalid_previous_revision_fails_closed(self):
        for before in ['', '0' * 40, '--help', 'main']:
            with self.subTest(before=before), self.assertRaises(ValueError):
                release.plan({'before': before}, self.environment)

    def test_registry_adds_only_signature(self):
        self.assertTrue(release.published('1.0.0', archive(), lambda _: archive(signed=True)))
        self.assertFalse(release.published('1.0.0', archive(), lambda _: None))
        with self.assertRaises(ValueError):
            release.published('1.0.0', archive(), lambda _: archive(b'changed'))

    def test_only_404_is_an_unpublished_version(self):
        for status in [401, 403, 429, 500]:
            with patch.object(release.urllib.request, 'urlopen', side_effect=urllib.error.HTTPError('https://example.invalid', status, '', {}, None)):
                with self.assertRaises(RuntimeError):
                    release.download('https://example.invalid')
        with patch.object(release.urllib.request, 'urlopen', side_effect=urllib.error.HTTPError('https://example.invalid', 404, '', {}, None)):
            self.assertIsNone(release.download('https://example.invalid'))

    def test_retry_does_not_upload_existing_identical_version(self):
        runner = Mock()
        release.publish('1.0.0', Path('package.nupkg'), archive(), self.environment, lambda _: archive(signed=True), runner)
        runner.assert_not_called()

    def test_collision_never_uploads(self):
        runner = Mock()
        with self.assertRaises(ValueError):
            release.publish('1.0.0', Path('package.nupkg'), archive(), self.environment, lambda _: archive(b'changed'), runner)
        runner.assert_not_called()

    def test_upload_verified_and_credentials_not_reported_on_failure(self):
        runner = Mock(return_value=SimpleNamespace(returncode=0))
        fetch = Mock(side_effect=[None, archive(signed=True)])
        self.assertEqual('Published and verified', release.publish('1.0.0', Path('package.nupkg'), archive(), self.environment, fetch, runner))
        self.assertNotIn('--skip-duplicate', runner.call_args.args[0])
        runner.return_value.returncode = 1
        with self.assertRaises(RuntimeError) as caught:
            release.publish('1.0.0', Path('package.nupkg'), archive(), self.environment, lambda _: None, runner)
        self.assertNotIn('synthetic-key', str(caught.exception))


if __name__ == '__main__':
    unittest.main()
