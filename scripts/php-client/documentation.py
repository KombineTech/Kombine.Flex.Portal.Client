"""Reviewed English, Danish and Spanish PHP integration text."""
import html
import re

TEXT = {
    'en': {
        'auth': {'Portal': 'Use a manager email and password for the tenant Portal API.', 'Equipment': 'Use a canonical service KID and its original API key for the tenant Equipment API. Manager credentials and Portal tokens are not accepted.'},
        'session': {'Portal': '`renew()` explicitly calls RenewManagerSession and stores the replacement token. Raw `renewManagerSession()` only returns the response. Renew while the bearer is unexpired, based on user activity; after expiry or revocation, log in again. There is no separate refresh token.', 'Equipment': 'There is no renewal/refresh token. Reuse the bearer until near expiry and log in again with the service key; spread scheduled logins with jitter.'},
        'permissions': {'Portal': 'Every business call still requires the manager’s account state, permitted Tab, KID scope and operation permission. A KID itself grants no access.', 'Equipment': 'Synchronization requires the predefined ServiceSync identity. Inspect SyncResponses.SyncError and each ResponseState even after HTTP 200. Persist incoming rows before acknowledging Success (1). On a deliberate replay after timeout, keep the original immutable keys and content; never create new timestamps.'},
        'details': {'Portal': 'Paging is explicit: keep the returned cursor and continue until it is absent, including after an empty page. Keep revision tokens for writes. Use a temporary file for downloads and rename it only after success.', 'Equipment': 'The Sync1 JSON field names are case-sensitive, including `UnitIds`, `MS2000`, `TagId` and `SyncKrumbData`. The client preserves the wire shape and never sends acknowledgements on its own.'},
        'intro': '64-bit PHP 8.2+, ext-curl and ext-json. No additional PHP libraries. Version 0.1.0 is included in the API downloads. It is not published to Packagist.',
        'install': 'Save the ZIP in your application’s packages/ folder, then install through Composer (ext-zip is needed during installation):',
        'manual': 'Without Composer: extract to flex-__LOWER__-client/ and require its autoload.php instead. Keep the complete src/ folder. The ZIP includes English, Danish and Spanish READMEs, operation and model references, and the public OpenAPI snapshot.',
        'variables': 'Supply tenantUrl and the login variables from protected application configuration or a login form. The API URL must end with /. Keep the bearer on the PHP server.',
        'limits': 'Responses use associative arrays; lists use indexed arrays. Use native 64-bit int for integer fields; preserve missing/null values. The client verifies TLS, refuses redirects, omits tokens on anonymous calls and clears the session on HTTP 401. Default limits: 30 seconds total, 16 MiB JSON, 64 KiB headers, 1 GiB per download. Downloads write to a caller-owned stream; discard partial files on failure. No automatic retries, paging, renewal or acknowledgements. Server-side PHP does not need browser CORS.',
        'errors': 'ApiException exposes status, apiCode and lowercase headers. 400: correct input; 401: sign in; 403: check permissions; 404/409: reload and resolve conflicts; 429: respect Retry-After; 5xx: handle temporary failure. TransportException and ProtocolException mean network/deadline or invalid/oversized data. A failed write may have completed: check state before retrying. Never log credentials, tokens or complete payloads.',
        'download': 'Download PHP ZIP', 'checksums': 'PHP checksums', 'changelog': 'API contract changelog',
    },
    'da': {
        'auth': {'Portal': 'Brug en administrators mail og adgangskode til tenantens Portal API.', 'Equipment': 'Brug et kanonisk service-KID og den oprindelige API-nøgle til tenantens Equipment API. Administratorlogin og Portal-tokens accepteres ikke.'},
        'session': {'Portal': '`renew()` kalder eksplicit RenewManagerSession og gemmer den nye token. Den rå `renewManagerSession()` returnerer kun svaret. Forny før udløb ud fra brugeraktivitet; efter udløb eller tilbagekaldelse kræves nyt login. Der er ingen særskilt refresh-token.', 'Equipment': 'Der er ingen fornyelse eller refresh-token. Genbrug bearer-tokenen til tæt på udløb og log ind igen med servicenøglen; fordel planlagte login med tilfældig forsinkelse.'},
        'permissions': {'Portal': 'Hvert forretningskald kontrollerer fortsat administratorens kontostatus, tilladte Tab, KID-område og operationsrettighed. Et KID giver ikke i sig selv adgang.', 'Equipment': 'Synkronisering kræver den foruddefinerede ServiceSync-identitet. Kontrollér SyncResponses.SyncError og hver ResponseState, også ved HTTP 200. Gem indgående rækker holdbart før kvittering med Success (1). Ved bevidst gentagelse efter timeout skal oprindelige uforanderlige nøgler og indhold bevares; opret aldrig nye tidsstempler.'},
        'details': {'Portal': 'Sideinddeling er eksplicit: genbrug den returnerede cursor, og fortsæt, til den mangler, også efter en tom side. Behold revisionstokens til skrivninger. Download til en midlertidig fil, og omdøb den først efter succes.', 'Equipment': 'Sync1-feltnavne skelner mellem store og små bogstaver, herunder `UnitIds`, `MS2000`, `TagId` og `SyncKrumbData`. Klienten bevarer formatet og sender aldrig kvitteringer på egen hånd.'},
        'intro': '64-bit PHP 8.2+, ext-curl og ext-json. Ingen ekstra PHP-biblioteker. Version 0.1.0 er med i API-downloads. Den er ikke udgivet på Packagist.',
        'install': 'Læg ZIP-filen i applikationens packages/-mappe, og installér med Composer (ext-zip kræves under installation):',
        'manual': 'Uden Composer: udpak i flex-__LOWER__-client/, og indlæs dens autoload.php i stedet. Behold hele src/-mappen. ZIP-filen indeholder engelske, danske og spanske README-filer, operationer, modeller og den offentlige OpenAPI-kontrakt.',
        'variables': 'Hent tenantUrl og loginvariabler fra beskyttet konfiguration eller en loginformular. API-adressen skal slutte med /. Behold bearer-tokenen på PHP-serveren.',
        'limits': 'Svar er associative arrays; lister er indekserede arrays. Brug 64-bit int til heltalsfelter, og bevar manglende/null-værdier. Klienten kontrollerer TLS, afviser redirects, udelader tokens ved anonyme kald og sletter sessionen ved HTTP 401. Standardgrænser: 30 sekunder i alt, 16 MiB JSON, 64 KiB headers og 1 GiB pr. download. Downloads skriver til en stream, som applikationen ejer; kassér delvise filer ved fejl. Ingen automatisk gentagelse, sideinddeling, fornyelse eller kvittering. Serverbaseret PHP kræver ikke browser-CORS.',
        'errors': 'ApiException giver status, apiCode og headers med små bogstaver. 400: ret input; 401: log ind; 403: kontrollér rettigheder; 404/409: genindlæs og løs konflikten; 429: respektér Retry-After; 5xx: håndter midlertidig fejl. TransportException og ProtocolException dækker netværk/tidsfrist og ugyldige/for store data. En fejlet skrivning kan være gennemført: kontrollér tilstanden før gentagelse. Log aldrig loginoplysninger, tokens eller fulde payloads.',
        'download': 'Hent PHP-ZIP', 'checksums': 'PHP-kontrolsummer', 'changelog': 'API-kontraktens changelog',
    },
    'es': {
        'auth': {'Portal': 'Usa el correo y la contraseña de un administrador para la API Portal del tenant.', 'Equipment': 'Usa un KID de servicio canónico y su clave API original para la API Equipment del tenant. No se aceptan credenciales de administrador ni tokens de Portal.'},
        'session': {'Portal': '`renew()` llama explícitamente a RenewManagerSession y guarda el token nuevo. `renewManagerSession()` solo devuelve la respuesta. Renueva antes de caducar y según la actividad del usuario; tras caducidad o revocación, inicia sesión de nuevo. No hay refresh-token separado.', 'Equipment': 'No hay renovación ni refresh-token. Reutiliza el bearer hasta cerca de su caducidad y vuelve a iniciar sesión con la clave del servicio; distribuye los accesos programados con una demora aleatoria.'},
        'permissions': {'Portal': 'Cada operación sigue comprobando el estado de la cuenta, Tab permitido, ámbito KID y permiso de operación del administrador. Un KID por sí solo no concede acceso.', 'Equipment': 'La sincronización requiere la identidad predefinida ServiceSync. Comprueba SyncResponses.SyncError y cada ResponseState incluso con HTTP 200. Guarda de forma duradera las filas recibidas antes de confirmar Success (1). Al repetir deliberadamente tras un timeout, conserva las claves inmutables y el contenido originales; nunca crees nuevas marcas de tiempo.'},
        'details': {'Portal': 'La paginación es explícita: reutiliza el cursor recibido y continúa hasta que falte, incluso tras una página vacía. Conserva las revisiones para escribir. Descarga a un archivo temporal y renómbralo solo tras completar la operación.', 'Equipment': 'Los nombres Sync1 distinguen mayúsculas, incluidos `UnitIds`, `MS2000`, `TagId` y `SyncKrumbData`. El cliente conserva el formato y nunca envía confirmaciones por su cuenta.'},
        'intro': 'PHP 8.2+ de 64 bits, ext-curl y ext-json. Sin bibliotecas PHP adicionales. La versión 0.1.0 está incluida en las descargas de la API. No está publicada en Packagist.',
        'install': 'Guarda el ZIP en packages/ dentro de la aplicación e instala con Composer (requiere ext-zip durante la instalación):',
        'manual': 'Sin Composer: extrae en flex-__LOWER__-client/ y carga su autoload.php. Conserva toda la carpeta src/. El ZIP incluye README en inglés, danés y español, operaciones, modelos y el contrato público OpenAPI.',
        'variables': 'Obtén tenantUrl y las variables de acceso desde configuración protegida o un formulario. La URL API debe terminar en /. Conserva el bearer en el servidor PHP.',
        'limits': 'Los objetos son arrays asociativos; las listas son arrays indexados. Usa int de 64 bits para campos enteros y conserva valores ausentes/null. El cliente verifica TLS, rechaza redirecciones, omite tokens en llamadas anónimas y elimina la sesión con HTTP 401. Límites predeterminados: 30 segundos totales, 16 MiB JSON, 64 KiB de cabeceras y 1 GiB por descarga. Las descargas escriben en un stream de la aplicación; descarta archivos parciales tras errores. Sin reintentos, paginación, renovación ni confirmaciones automáticas. PHP en el servidor no necesita CORS del navegador.',
        'errors': 'ApiException expone status, apiCode y cabeceras en minúsculas. 400: corrige los datos; 401: inicia sesión; 403: revisa permisos; 404/409: recarga y resuelve conflictos; 429: respeta Retry-After; 5xx: gestiona el fallo temporal. TransportException y ProtocolException indican fallos de red/plazo o datos incorrectos/demasiado grandes. Una escritura fallida puede haberse completado: comprueba el estado antes de repetirla. No registres credenciales, tokens ni payloads completos.',
        'download': 'Descargar ZIP PHP', 'checksums': 'Sumas de comprobación PHP', 'changelog': 'Changelog del contrato API',
    },
}

PORTAL_EXAMPLE = '''```php
$page = $api->getBankUsers($bankKid, ['pageSize' => 25, 'sort' => 'number']);
$balances = $api->getBankUserBalances($bankKid, ['userKids' => $userKids]);
$receipts = $api->getUserReceipts($userKid, ['offset' => 0]);
// Request the next page only when needed, using nextOffset and the same revision.
$stream = fopen($temporaryPath, 'w+b');
try {
    $download = $api->exportBankUsers($bankKid, $stream);
} finally {
    fclose($stream);
}
rename($temporaryPath, $completedPath);
```'''
EQUIPMENT_EXAMPLE = '''```php
$sync = $api->syncEquipment($locationKid, 2, ['UnitIds' => [1]]);
$syncError = $sync['SyncResponses']['SyncError'] ?? null;
$rows = $sync['SyncKrumbData'] ?? [];
```'''


def generate(root, project, api, count, write):
    lower = api.lower()
    version = '0.4.2' if api == 'Portal' else '0.1.0'
    archive = f'kombine-flex-{lower}-client-php-{version}.zip'
    domain = 'technology' if api == 'Portal' else 'equipment'
    login = '$email, $password' if api == 'Portal' else '$serviceKid, $apiKey'
    first = 'getCurrentManager' if api == 'Portal' else 'getEquipmentStatus'
    for language, strings in TEXT.items():
        suffix = '' if language == 'en' else '.' + language
        template = (root / f'scripts/php-client/README{suffix}.md').read_text(encoding='utf-8')
        details = strings['details'][api] + '\n\n' + (PORTAL_EXAMPLE if api == 'Portal' else EQUIPMENT_EXAMPLE)
        replacements = {'API': api, 'LOWER': lower, 'COUNT': str(count), 'ZIP': archive,
                        'ORIGIN': f'https://api.team.kombine.{domain}', 'AUTH': strings['auth'][api],
                        'SESSION': strings['session'][api], 'PERMISSIONS': strings['permissions'][api],
                        'LOGIN': login, 'FIRST': first, 'RAWLOGIN': 'loginManager' if api == 'Portal' else 'loginService', 'DETAILS': details}
        for key, value in replacements.items(): template = template.replace('__' + key + '__', value)
        template = template.replace('0.1.0', version)
        if api == 'Portal':
            receipts = {
                'en': 'Version 0.2.5 adds GetUserReceipts and GetHostingMetrics for API releases that expose these operations. Load receipts on demand, starting at offset 0. Continue with nextOffset and the same revision; on HTTP 409 (receipts-changed), discard earlier pages and restart at offset 0. Keep currencies separate and minor-unit amounts as 64-bit integers. See /docs#user-receipts and /docs#hosting for permissions and limits.',
                'da': 'Version 0.2.5 tilføjer GetUserReceipts og GetHostingMetrics til API-releases, som tilbyder disse operationer. Indlæs kvitteringer efter behov fra offset 0. Fortsæt med nextOffset og samme revision; ved HTTP 409 (receipts-changed) skal tidligere sider kasseres, og indlæsningen genstartes ved offset 0. Hold valutaer adskilt og beløb som 64-bit heltal i mindste valutaenhed. Se /docs#user-receipts og /docs#hosting for rettigheder og grænser.',
                'es': 'La versión 0.2.5 añade GetUserReceipts y GetHostingMetrics para versiones de la API que ofrecen estas operaciones. Cargue los recibos bajo demanda desde offset 0. Continúe con nextOffset y la misma revision; ante HTTP 409 (receipts-changed), descarte las páginas anteriores y reinicie en offset 0. Mantenga las monedas separadas y los importes como enteros de 64 bits en unidades menores. Consulte /docs#user-receipts y /docs#hosting para los permisos y límites.'
            }[language]
            locations = {
                'en': 'Version 0.2.5 adds GetLocationOpeningHours and GetLocationBookingRules. Both require Location Read, Unit Read and the authorized location scope. Reservation rules contain plain text plus ordered parts with text/isValue for optional value emphasis; never render these strings as HTML. Keep text as the fallback for older responses. See /docs#location-opening-hours and /docs#location-booking-rules for permissions, examples and limits.',
                'da': 'Version 0.2.5 tilføjer GetLocationOpeningHours og GetLocationBookingRules. Begge kræver Location Read, Unit Read og adgang til lokationen. Reservationsregler indeholder ren tekst samt ordnede parts med text/isValue til valgfri fremhævning; vis aldrig strengene som HTML. Brug text som fallback for ældre svar. Se /docs#location-opening-hours og /docs#location-booking-rules for rettigheder, eksempler og grænser.',
                'es': 'La versión 0.2.5 añade GetLocationOpeningHours y GetLocationBookingRules. Ambas requieren Location Read, Unit Read y acceso a la ubicación. Las reglas contienen texto plano y parts ordenadas con text/isValue para resaltar valores de forma opcional; nunca interprete estas cadenas como HTML. Use text como alternativa para respuestas anteriores. Consulte /docs#location-opening-hours y /docs#location-booking-rules para permisos, ejemplos y límites.',
            }[language]
            metadata = {'en': 'Version 0.2.5 adds optional latestPostingMs2000 and hasActiveSubscription fields to GetBankUserBalances. The posting time is a 64-bit UTC millisecond count since 2000-01-01; zero means no postings. Null or an absent field means unknown, and missing or hidden residents return null. Subscription status is not payment confirmation. Keep existing balance handling and permissions; see /docs#user-balances.', 'da': 'Version 0.2.5 tilføjer de valgfrie felter latestPostingMs2000 og hasActiveSubscription til GetBankUserBalances. Posteringstidspunktet er et 64-bit antal UTC-millisekunder siden 2000-01-01; nul betyder ingen posteringer. Null eller et manglende felt betyder ukendt, og manglende eller skjulte beboere giver null. Abonnementsstatus bekræfter ikke en betaling. Bevar eksisterende saldohåndtering og rettigheder; se /docs#user-balances.', 'es': 'La versión 0.2.5 añade los campos opcionales latestPostingMs2000 y hasActiveSubscription a GetBankUserBalances. La fecha del asiento es un entero de 64 bits en milisegundos UTC desde 2000-01-01; cero indica que no hay asientos. Null o un campo ausente significa desconocido; los residentes inexistentes u ocultos devuelven null. El estado de suscripción no confirma un pago. Mantenga el tratamiento de saldos y los permisos existentes; consulte /docs#user-balances.'}[language]
            timeout_note = {'en': 'Version 0.3.1 synchronizes GetBankUserBalances documentation with its 20-second database deadline. Request and response fields are unchanged. Allow extra time for transport and authorization; HTTP 503 still returns no partial balances.', 'da': 'Version 0.3.1 opdaterer dokumentationen for GetBankUserBalances til den nye databasefrist på 20 sekunder. Felter i kald og svar er uændrede. Giv ekstra tid til transport og adgangskontrol; HTTP 503 returnerer fortsat ingen delvise saldoer.', 'es': 'La versión 0.3.1 actualiza la documentación de GetBankUserBalances al plazo de base de datos de 20 segundos. Los campos de solicitud y respuesta no cambian. Reserve tiempo adicional para transporte y autorización; HTTP 503 sigue sin devolver saldos parciales.'}[language]
            receipts = timeout_note + ' ' + metadata + ' ' + locations + ' ' + receipts
            template = template.replace('\n## ', '\n' + receipts + '\n\n## ', 1)
            migration = {
                'en': 'For this beta candidate, migrate response fields icon/bankIcon/unitIcon to iconKid/bankIconKid/unitIconKid and use icon routes with an explicit set. See the API changelog for the removed paths. Application downloads return DownloadResponse and write bytes to the supplied stream.',
                'da': 'Til denne beta-kandidat skal svarfelterne icon/bankIcon/unitIcon ændres til iconKid/bankIconKid/unitIconKid, og ikonruter skal have et eksplicit ikonsæt. Se API-changelog for de fjernede stier. Appdownloads returnerer DownloadResponse og skriver bytes til den angivne stream.',
                'es': 'Para este candidato beta, cambie los campos icon/bankIcon/unitIcon por iconKid/bankIconKid/unitIconKid y use rutas de iconos con un conjunto explícito. Consulte el registro de cambios para las rutas eliminadas. Las descargas de aplicaciones devuelven DownloadResponse y escriben bytes en el stream proporcionado.'
            }[language]
            position = template.find('\n## ')
            template = template[:position] + '\n' + migration + '\n' + template[position:]
        if api == 'Portal':
            template = {'da': 'Version 0.4.2: GetLocations kræver nu fields=vismaCustNo,bankActivationCode,locationActivationCode for at bevare de tidligere valgfrie værdier; accepter null for fravalgte felter. Behold samme fields under sideskift, og start gamle cursors forfra. Nye forslag til beboernumre er skrivebeskyttede og reserverer ikke et nummer. Aktiveringssvar indeholder qrCodeDataV1 og qrCodeDataV2 (fem værdier med 30-bit støj/kontrolsum); behandl begge som legitimationsoplysninger. Se /docs#changelog for migrering og /docs for rettigheder og fejlhåndtering.', 'es': 'Versión 0.4.2: GetLocations requiere ahora fields=vismaCustNo,bankActivationCode,locationActivationCode para conservar los valores opcionales anteriores; acepte null para campos no seleccionados. Mantenga fields al paginar y reinicie los cursores anteriores. Las nuevas sugerencias de números de residentes son de solo lectura y no reservan un número. Las respuestas de activación incluyen qrCodeDataV1 y qrCodeDataV2 (cinco valores con ruido y suma de comprobación de 30 bits); trate ambos como credenciales. Consulte /docs#changelog para la migración y /docs para permisos y errores.', 'en': 'Version 0.4.2: GetLocations now requires fields=vismaCustNo,bankActivationCode,locationActivationCode to retain the previous optional values; accept null for unselected fields. Keep fields unchanged while paging and restart old cursors. New resident-number suggestions are read-only and do not reserve a number. Activation responses include qrCodeDataV1 and qrCodeDataV2 (five values with 30-bit noise/checksum); treat both as credentials. See /docs#changelog for migration and /docs for permissions and error handling.'}[language] + '\n\n' + template
        write(project / f'README{suffix}.md', template)
        code = re.search(r'```php\n(.*?)\n```', template, re.S)[1]
        def paragraph(text):
            return '<p>' + re.sub(r'`([^`]+)`', r'<code>\1</code>', html.escape(text)) + '</p>\n'
        section = '<!-- PHP_CLIENT_START -->\n<section id="php-client" data-doc-panel>\n<h2>PHP · ' + api + ' API</h2>\n'
        section += paragraph(strings['intro'].replace('0.1.0', version))
        if api == 'Portal': section += paragraph(receipts)
        if api == 'Equipment':
            internal_label = {'en': 'Internal Kombine artifact', 'da': 'Intern Kombine-fil', 'es': 'Archivo interno de Kombine'}[language]
            section += f'<p><span>{internal_label}: <code>{archive}</code></span> · <span>{internal_label}: <code>php-manifest.json</code></span> · <a href="#changelog">{strings["changelog"]}</a></p>\n'
        else:
            section += f'<p><a href="/docs/downloads/{archive}" download>{strings["download"]}</a> · <a href="/docs/downloads/php-manifest.json">{strings["checksums"]}</a> · <a href="#changelog">{strings["changelog"]}</a></p>\n'
        section += paragraph(strings['install'])
        section += f'<pre><code>composer config repositories.kombine artifact ./packages\ncomposer require kombine/flex-{lower}-client:{version}</code></pre>\n'
        section += paragraph(strings['manual'].replace('__LOWER__', lower))
        section += paragraph(strings['auth'][api] + ' ' + strings['variables'])
        section += '<pre><code class="language-php">' + html.escape(code) + '</code></pre>\n'
        section += paragraph(strings['session'][api]) + paragraph(strings['permissions'][api])
        section += paragraph(strings['details'][api])
        example = PORTAL_EXAMPLE if api == 'Portal' else EQUIPMENT_EXAMPLE
        section += '<pre><code class="language-php">' + html.escape(example.removeprefix('```php\n').removesuffix('\n```')) + '</code></pre>\n'
        section += paragraph(strings['errors']) + paragraph(strings['limits'])
        section += '</section>\n<!-- PHP_CLIENT_END -->'
        guide = root / f'Kombine.Flex.{api}.Api/Documentation/index{suffix}.html'
        if not guide.exists():
            continue
        original = guide.read_text(encoding='utf-8')
        if '<!-- PHP_CLIENT_START -->' in original:
            updated = re.sub(r'<!-- PHP_CLIENT_START -->.*?<!-- PHP_CLIENT_END -->', lambda _: section, original, flags=re.S)
        else:
            assert '<!-- API_CHANGELOG -->' in original
            updated = original.replace('<!-- API_CHANGELOG -->', section + '\n<!-- API_CHANGELOG -->')
        if 'id="tab-php-client"' not in updated:
            match = re.search(r'<a\b[^>]*id="tab-changelog"', updated)
            assert match
            updated = updated[:match.start()] + '<a id="tab-php-client" href="#php-client">PHP</a>\n  ' + updated[match.start():]
        write(guide, updated)
