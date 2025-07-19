# 41. Repository Pattern vs Direct DbContext

## Bad: Direct usage of DbContext
- Every consumer directly instantiates and queries the DbContext.
- Violates the **Single Responsibility Principle**.
- Tightly couples business logic to EF Core.
- Makes testing hard (requires in-memory DB or mocking DbContext).

## Good: Repository abstraction
- Introduces an interface (`IStudentRepository`) to abstract the data access logic.
- DbContext is encapsulated inside the repository.
- Promotes **loose coupling** and **testability**.
- Makes the transition to a different ORM or source (API, cache) possible without rewriting business logic.

## When to Use
- Always in medium to large applications.
- When decoupling and testing are priorities.

## When to Avoid
- Very small or one-off utilities (e.g., quick admin scripts).
