# 49. Poor Modular Boundaries in Monoliths

## Bad: Tightly Coupled Modules

- `OrderProcessor` directly depends on `EmailService`
- No abstraction, cannot switch to SMS or log-based notification
- Breaks **Open/Closed Principle**
- Difficult to unit test or reuse

## Good: Interface-Based Decoupling

- `OrderProcessor` depends on `INotificationService`
- Email, SMS, logging, etc. can be injected
- Improves modularity and maintainability
- Enables unit testing with mocks/stubs

## Best Practice

- Always define module boundaries with interfaces
- Concrete implementations should be replaceable without changing the caller
- Keep domain logic independent of infrastructure
