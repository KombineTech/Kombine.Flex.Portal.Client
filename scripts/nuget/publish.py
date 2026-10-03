"""Publish only a version-increasing main push of the public Portal NuGet client."""
import argparse
import hashlib
import io
import json
import os
from pathlib import Path
import re
import subprocess
import sys
import time
import urllib.error
import urllib.request
import xml.etree.ElementTree as ET
import zipfile

ROOT = Path(__file__).resolve().parents[2]
PACKAGE = 'Kombine.Flex.Portal.Client'
PROJECT = f'{PACKAGE}/{PACKAGE}.csproj'
REPOSITORY = 'KombineTech/Kombine.Flex.Portal.Client'
SOURCE = 'https://api.nuget.org/v3/index.json'
LIMIT = 32 * 1024 * 1024


def identity(source):
    project = ET.fromstring(source)
    version = project.findtext('.//Version')
    if project.findtext('.//PackageId') != PACKAGE:
        raise ValueError('Only the Portal NuGet client can be published.')
    if not re.fullmatch(r'(0|[1-9]\d*)\.(0|[1-9]\d*)\.(0|[1-9]\d*)', version or ''):
        raise ValueError('Use a stable major.minor.patch package version.')
    return version


def increased(previous, current):
    old = tuple(map(int, previous.split('.')))
    new = tuple(map(int, current.split('.')))
    if new < old:
        raise ValueError('Package versions must not decrease.')
    return new > old


def require_main(environment):
    if (environment.get('GITHUB_REPOSITORY') != REPOSITORY
            or environment.get('GITHUB_EVENT_NAME') != 'push'
            or environment.get('GITHUB_REF') != 'refs/heads/main'):
        raise ValueError('Publishing requires a push to the public client main branch.')


def plan(event, environment=os.environ, run=subprocess.check_output):
    require_main(environment)
    before = event.get('before', '')
    if not re.fullmatch(r'[a-f0-9]{40}', before) or before == '0' * 40:
        raise ValueError('A previous main revision is required to compare versions.')
    previous = identity(run(['git', 'show', f'{before}:{PROJECT}'], cwd=ROOT))
    version = identity((ROOT / PROJECT).read_bytes())
    return version, increased(previous, version)


def payload(data):
    with zipfile.ZipFile(io.BytesIO(data)) as archive:
        entries = [item for item in archive.infolist() if not item.is_dir()]
        if len({item.filename.casefold() for item in entries}) != len(entries):
            raise ValueError('Duplicate package entries.')
        if sum(item.file_size for item in entries) > LIMIT:
            raise ValueError('Package is too large.')
        return {item.filename: hashlib.sha256(archive.read(item)).hexdigest()
                for item in entries if item.filename != '.signature.p7s'}


def package(version):
    if identity((ROOT / PROJECT).read_bytes()) != version:
        raise ValueError('The package version differs from the main push.')
    path = ROOT / 'artifacts/packages' / f'{PACKAGE}.{version}.nupkg'
    data = path.read_bytes()
    payload(data)
    with zipfile.ZipFile(io.BytesIO(data)) as archive:
        metadata = ET.fromstring(archive.read(f'{PACKAGE}.nuspec')).find('{*}metadata')
        if metadata.findtext('{*}id') != PACKAGE or metadata.findtext('{*}version') != version:
            raise ValueError('Unexpected package identity.')
        for dependency in metadata.findall('.//{*}dependency'):
            if dependency.attrib.get('id', '').lower().startswith('kombine'):
                raise ValueError('Public clients must not depend on private Kombine packages.')
        for framework in ('netstandard2.0', 'net8.0', 'net10.0'):
            archive.getinfo(f'lib/{framework}/{PACKAGE}.dll')
    return path, data


def download(url):
    try:
        with urllib.request.urlopen(url, timeout=30) as response:
            data = response.read(LIMIT + 1)
            if len(data) > LIMIT:
                raise ValueError('Remote package is too large.')
            return data
    except urllib.error.HTTPError as error:
        if error.code == 404:
            return None
        raise RuntimeError(f'NuGet lookup failed with HTTP {error.code}.') from None


def published(version, data, fetch=download):
    name = PACKAGE.lower()
    remote = fetch(f'https://api.nuget.org/v3-flatcontainer/{name}/{version}/{name}.{version}.nupkg')
    if remote is None:
        return False
    if payload(remote) != payload(data):
        raise ValueError('This version already exists with different contents. Increase the version.')
    return True


def publish(version, path, data, environment=os.environ, fetch=download, run=subprocess.run, sleep=time.sleep):
    require_main(environment)
    if published(version, data, fetch):
        return 'Already published; contents verified'
    key = environment.get('NUGET_API_KEY')
    if not key:
        raise ValueError('NuGet Trusted Publishing did not supply a temporary key.')
    result = run(['dotnet', 'nuget', 'push', str(path), '--api-key', key,
                  '--source', SOURCE, '--timeout', '300'], capture_output=True, text=True)
    if result.returncode:
        raise RuntimeError('NuGet push failed. Check validation before rerunning the same workflow.')
    for _ in range(20):
        if published(version, data, fetch):
            return 'Published and verified'
        sleep(15)
    raise RuntimeError('Upload accepted but not yet visible. Check NuGet validation, then rerun this workflow.')


def output(**values):
    if os.environ.get('GITHUB_OUTPUT'):
        with open(os.environ['GITHUB_OUTPUT'], 'a', encoding='utf-8') as stream:
            for key, value in values.items():
                stream.write(f'{key}={str(value).lower() if isinstance(value, bool) else value}\n')


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('command', choices=('plan', 'preflight', 'publish'))
    args = parser.parse_args()
    # Recheck the original push even on a rerun; never trust a caller-supplied version.
    version, changed = plan(json.loads(Path(os.environ['GITHUB_EVENT_PATH']).read_text(encoding='utf-8')))
    if args.command == 'plan':
        output(version=version, changed=changed)
        print(f'{PACKAGE} {version}: ' + ('new version' if changed else 'unchanged; no publication'))
        return
    if not changed:
        raise ValueError('No version increase in this push.')
    path, data = package(version)
    if args.command == 'preflight':
        pending = not published(version, data)
        if pending and not os.environ.get('NUGET_USER', '').strip():
            raise ValueError('Configure NUGET_USER and the nuget.org Trusted Publishing policy described in README.md.')
        output(needs_publish=pending)
        return
    status = publish(version, path, data)
    url = f'https://www.nuget.org/packages/{PACKAGE}/{version}'
    print(f'{status}: {url}')
    if os.environ.get('GITHUB_STEP_SUMMARY'):
        with open(os.environ['GITHUB_STEP_SUMMARY'], 'a', encoding='utf-8') as stream:
            stream.write(f'## Portal NuGet\n\n[{PACKAGE} {version}]({url}): {status}.\n\n'
                         f'Commit: `{os.environ["GITHUB_SHA"]}`\n\nSHA-256: `{hashlib.sha256(data).hexdigest()}`\n')


if __name__ == '__main__':
    try:
        main()
    except Exception as error:
        print(f'NuGet release stopped: {error}', file=sys.stderr)
        sys.exit(1)
