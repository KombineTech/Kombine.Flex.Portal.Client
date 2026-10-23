"""Build the reviewed Portal Dart source ZIP; never publishes to a registry."""
from pathlib import Path
from dart_client.package import build
root=Path(__file__).resolve().parents[1]
build(root/'Kombine.Flex.Portal.Client.Dart',root/'artifacts/packages')
