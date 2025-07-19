# 44. Domain Services vs Application Services

## Bad: BusinessLogicInApplicationService
- Application service contains business rules like eligibility checks.
- This violates **Separation of Concerns**.
- Difficult to reuse or test business logic independently of the app service.

## Good: ProperDomainServiceUse
- Business logic moved to `DiscountDomainService`, a domain service.
- Application service is only orchestrating workflow, not making decisions.
- Easier to unit test business logic and use across different applications (e.g., web, API, jobs).

## Why It Matters
- Domain services are central to Domain-Driven Design.
- Keeps business logic close to domain entities and reusable across bounded contexts.
- Application services should only handle user requests, validation, and orchestration—not business rules.

