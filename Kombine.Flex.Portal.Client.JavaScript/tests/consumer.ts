import { PortalClient, PortalApiError, type UserCurrencyBalanceItem, type LocationWeatherResponse, type ManagerLoginRequest } from "../dist/index.js";

const client = new PortalClient("https://api.example.test/");
const credentials: ManagerLoginRequest = { email: "x@example.test", password: "fixture" };
void client.loginManager(credentials);
void client.getBankAccount("bank-kid", { includeZero: false, period: 0 });
void client.getLocationUnits("location-kid", { acceptLanguage: "da-DK" });
void client.getBankUserBalances("bank-kid", { userKids: ["user-kid"] });
const amount: UserCurrencyBalanceItem = { currentBalanceMinor: 9223372036854775807n };
void amount;
// @ts-expect-error int64 values deliberately use bigint, never a potentially rounded number.
const invalid: UserCurrencyBalanceItem = { currentBalanceMinor: 9007199254740993 };
// Alternative manager credentials have no globally required email/password pair.
void client.loginManager({ kid: "manager-kid", apiKey: "fixture-key" });
// @ts-expect-error API keys are strings even though the alternative login fields are optional.
void client.loginManager({ kid: "manager-kid", apiKey: 123 });
// @ts-expect-error Query options use idiomatic camelCase rather than wire PascalCase.
void client.getBankAccount("kid", { IncludeZero: false });
const error = new PortalApiError(403, '{"code":"forbidden"}', new Headers());
const code: string | undefined = error.code;
void code;

const unavailableWeather: LocationWeatherResponse = { status: "Unavailable", current: null };
void client.getLocationWeather("location-kid");
void unavailableWeather;
// @ts-expect-error Current is a typed measurement object or null, never an arbitrary value.
const invalidWeather: LocationWeatherResponse = { current: "not-weather" };
