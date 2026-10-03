import { PortalClient, PortalApiError, type UserCurrencyBalanceItem, type ManagerLoginRequest } from "../dist/index.js";

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
// @ts-expect-error Password is a required request field.
void client.loginManager({ email: "x@example.test" });
// @ts-expect-error Query options use idiomatic camelCase rather than wire PascalCase.
void client.getBankAccount("kid", { IncludeZero: false });
const error = new PortalApiError(403, '{"code":"forbidden"}', new Headers());
const code: string | undefined = error.code;
void code;
