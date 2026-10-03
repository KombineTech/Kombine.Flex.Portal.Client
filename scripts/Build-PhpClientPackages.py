"""Build, verify and bundle the Portal PHP package; never publish or deploy."""
import argparse
import hashlib
import json
import os
from pathlib import Path
import shutil
import subprocess
import sys
import tempfile
import zipfile

ROOT = Path(__file__).resolve().parent.parent
parser = argparse.ArgumentParser(description=__doc__)
parser.add_argument('--php', default='php')
parser.add_argument('--extension-dir')
parser.add_argument('--composer', help='Optional local composer.phar for offline install verification.')
parser.add_argument('--api', choices=('Portal',), help='Build only the changed API client; Portal only.')
args = parser.parse_args()
output = ROOT / 'artifacts/packages'
output.mkdir(parents=True, exist_ok=True)
php = [str(Path(args.php).resolve()) if Path(args.php).is_file() else args.php]
if args.extension_dir:
    php += ['-n', '-d', 'extension_dir=' + str(Path(args.extension_dir).resolve()), '-d', 'extension=curl', '-d', 'extension=openssl', '-d', 'extension=zip']
packages = []
versions = {}
with tempfile.TemporaryDirectory(prefix='kombine-php-packages-') as temp:
    temp = Path(temp)
    for api in ('Portal',):
        project = ROOT / f'Kombine.Flex.{api}.Client.Php'
        if args.api and api != args.api:
            shutil.copytree(project, temp / project.name)
            versions[api] = json.loads((project / 'composer.json').read_text(encoding='utf-8'))['version']
            continue
        version = json.loads((project / 'composer.json').read_text(encoding='utf-8'))['version']
        versions[api] = version
        filename = f'kombine-flex-{api.lower()}-client-php-{version}.zip'
        archive = output / filename
        files = sorted([project / name for name in ('autoload.php', 'composer.json', 'README.md', 'README.da.md', 'README.es.md', 'OPERATIONS.md', 'MODELS.md')]
                       + list((project / 'src').glob('*')) + list((project / 'OpenApi').glob('*.json')))
        with zipfile.ZipFile(archive, 'w', compression=zipfile.ZIP_DEFLATED, compresslevel=9) as zipped:
            for path in files:
                info = zipfile.ZipInfo(path.relative_to(project).as_posix(), date_time=(2026, 1, 1, 0, 0, 0))
                info.compress_type = zipfile.ZIP_DEFLATED
                info.external_attr = 0o100644 << 16
                zipped.writestr(info, path.read_bytes())
        with zipfile.ZipFile(archive) as zipped:
            assert zipped.testzip() is None
            assert set(zipped.namelist()) == {p.relative_to(project).as_posix() for p in files}
            for language in ('', '.da', '.es'):
                assert '/docs#changelog' in zipped.read(f'README{language}.md').decode('utf-8')
            zipped.extractall(temp / project.name)
        manifest = dict(version=version, openApiSha256=hashlib.sha256((project / f'OpenApi/{api.lower()}.openapi.json').read_bytes()).hexdigest(),
                        packages=[dict(file=filename, bytes=archive.stat().st_size, sha256=hashlib.sha256(archive.read_bytes()).hexdigest())])
        packages.append((api, archive, manifest))
    command = [sys.executable, str(ROOT / 'scripts/Test-PhpClients.py'), '--php', php[0], '--packages-root', str(temp)]
    if args.extension_dir: command += ['--extension-dir', str(Path(args.extension_dir).resolve())]
    subprocess.run(command, check=True)
    if args.composer:
        composer = str(Path(args.composer).resolve())
        archives = temp / 'archives'
        archives.mkdir()
        for _, archive, _ in packages: shutil.copyfile(archive, archives / archive.name)
        consumer = temp / 'consumer'
        consumer.mkdir()
        config = {'name': 'kombine/php-client-install-check', 'version': '1.0.0', 'description': 'Offline test consumer', 'license': 'proprietary',
                  'repositories': [{'type': 'artifact', 'url': str(archives)}, {'packagist.org': False}],
                  'require': {'kombine/flex-portal-client': versions['Portal']}}
        (consumer / 'composer.json').write_text(json.dumps(config), encoding='utf-8')
        env = dict(os.environ, COMPOSER_HOME=str(temp / 'composer-home'), COMPOSER_CACHE_DIR=str(temp / 'composer-cache'), COMPOSER_DISABLE_NETWORK='1')
        for api, _, _ in packages:
            subprocess.run(php + [composer, 'validate', '--strict', '--no-check-publish', '--no-check-version', str(temp / f'Kombine.Flex.{api}.Client.Php/composer.json')], env=env, check=True)
        subprocess.run(php + [composer, 'install', '--no-interaction', '--no-plugins', '--no-scripts'], cwd=consumer, env=env, check=True)
        (consumer / 'check.php').write_text("<?php\nrequire __DIR__ . '/vendor/autoload.php';\n"
            "$p = new Kombine\\Flex\\Portal\\PortalClient('https://example.invalid/');\n"
            "if ($p->getAccessToken() !== null) exit(1);\n"
            "echo 'Portal Composer package installed and autoloaded offline.', PHP_EOL;\n", encoding='utf-8')
        subprocess.run(php + ['check.php'], cwd=consumer, check=True)
    else:
        print('Composer install check not run; pass --composer /path/to/composer.phar to enable it.')
    # Mutate bundled downloads only after all requested checks pass.
    for api, archive, manifest in packages:
        destination = ROOT / 'artifacts/downloads'
        destination.mkdir(parents=True, exist_ok=True)
        shutil.copyfile(archive, destination / archive.name)
        (destination / 'php-manifest.json').write_text(json.dumps(manifest, indent=2) + '\n', encoding='utf-8', newline='\n')
        print(f'Bundled {archive.name} ({archive.stat().st_size} bytes); no publication or deployment.')
