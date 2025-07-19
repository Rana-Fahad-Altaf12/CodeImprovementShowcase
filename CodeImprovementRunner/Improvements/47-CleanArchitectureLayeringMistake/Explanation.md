# 47. Clean Architecture Layering Mistake

## Bad: UI -> Repository

- UI directly references `UserRepository`
- No application/business layer
- Breaks **layer separation**
- Makes testing and refactoring harder

## Good: UI -> Application Layer -> Repository

- UI calls application service (`UserService`)
- Business logic stays in service layer
- Repository is accessed only from inside service
- Layers:
  - UI: Receives input
  - Application Layer: Business rules
  - Infrastructure Layer: Data access

## Best Practice

Follow Clean Architecture:

- UI should never call data access directly
- Application layer should mediate all use cases
- Use Dependency Injection for wiring
