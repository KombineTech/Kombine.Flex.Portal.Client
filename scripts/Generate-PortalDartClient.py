"""Generate the public Portal Dart client from the committed API snapshot."""
import argparse
from pathlib import Path
from dart_client.generate import generate
parser=argparse.ArgumentParser(description=__doc__)
parser.add_argument('--check',action='store_true')
args=parser.parse_args()
root=Path(__file__).resolve().parents[1]
generate(root/'Kombine.Flex.Portal.Client.Dart',root/'Kombine.Flex.Portal.Client/OpenApi/portal.openapi.json',
         'Portal','kombine_flex_portal_client',args.check)
