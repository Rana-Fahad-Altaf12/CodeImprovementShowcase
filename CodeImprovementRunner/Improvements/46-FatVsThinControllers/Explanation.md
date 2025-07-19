# 46. Fat Controllers vs Thin Controllers

## Bad: FatController

- Controller contains business logic:
  - Email validation
  - Saving to database
  - Sending email
- Hard to test, maintain, and reuse
- Violates **Separation of Concerns**

## Good: ThinControllerWithService

- Controller only handles HTTP request/response
- Delegates logic to `UserRegistrationService`
- Easier to:
  - Test service logic in isolation
  - Maintain and scale
  - Reuse services in other contexts (e.g., background jobs)

## Best Practice

- Keep controllers thin.
- Push business logic to **application services**.
