# 71. Repository pattern vs direct DbContext

## Bad
Service depends directly on a data context:
- Business logic is tightly coupled to data access details.
- Harder to unit test (you must spin up the context).
- Query logic gets duplicated across services.

## Good
Introduce a repository abstraction:
- Service depends on `IStudentRepository`, not the context.
- Centralizes query logic and reduces duplication.
- Easier to mock for tests and to change storage later.

Prefer depending on an abstraction (repository) over a concrete data context in business logic.
