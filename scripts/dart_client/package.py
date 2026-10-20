"""Build deterministic source archives, refusing same-version content replacement."""
from pathlib import Path
import hashlib,io,json,re,zipfile

def build(project,output):
    project,output=Path(project),Path(output)
    version=re.search(r'^version:\s*(\d+\.\d+\.\d+)\s*$',(project/'pubspec.yaml').read_text(),re.M).group(1)
    paths=[project/p for p in ['pubspec.yaml','CHANGELOG.md','README.md','README.da.md','README.es.md','OPERATIONS.md']]
    for folder in ['lib','example','OpenApi','test']:
        paths.extend(p for p in (project/folder).rglob('*') if p.is_file())
    if any(not p.exists() for p in paths):raise ValueError('Incomplete source package.')
    payload=io.BytesIO()
    with zipfile.ZipFile(payload,'w',compression=zipfile.ZIP_DEFLATED,compresslevel=9) as archive:
        for path in sorted(paths):
            relative=path.relative_to(project).as_posix()
            entry=zipfile.ZipInfo(project.name+'/'+relative,date_time=(1980,1,1,0,0,0))
            entry.compress_type=zipfile.ZIP_DEFLATED;entry.external_attr=0o644<<16
            archive.writestr(entry,path.read_text(encoding='utf-8-sig').replace('\r\n','\n').encode())
    data=payload.getvalue();output.mkdir(parents=True,exist_ok=True)
    destination=output/(project.name+'.'+version+'.zip')
    if destination.exists() and destination.read_bytes()!=data:
        raise ValueError('Archive contents changed: increment the package version before rebuilding.')
    destination.write_bytes(data)
    record=dict(version=version,file=destination.name,bytes=len(data),sha256=hashlib.sha256(data).hexdigest())
    (output/(project.name+'.manifest.json')).write_text(json.dumps(record,indent=2)+'\n')
    print(f'Built {destination.name}: {len(data)} bytes. Nothing published.')
    return destination
