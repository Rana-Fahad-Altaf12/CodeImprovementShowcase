# 59. Global error handler vs scattered try-catch

## Bad
Scattered try-catch blocks:
- Duplicate error handling logic everywhere.
- Noise in logs and repeated messages.
- Hard to maintain and inconsistent error policies.

## Good
Use a global error handler:
- Catch and log once at the application boundary.
- Keep business logic clean (methods throw, not log).
- Centralized handling makes errors easier to track and maintain.

Centralize error handling instead of scattering try-catch.
