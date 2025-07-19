# 45. Violating SRP in Services

## Bad: FatServiceWithMultipleResponsibilities

- `UserAccountService` performs **validation**, **persistence**, and **email sending**.
- Breaks **Single Responsibility Principle (SRP)**.
- Harder to test, maintain, and reuse.

## Good: SplitResponsibilitiesIntoServices

- Responsibilities are split into:
  - `EmailValidator`
  - `UserRepository`
  - `EmailService`
- `UserAccountService` focuses only on **orchestration**.

## Why It Matters

- Following SRP leads to:
  - Smaller, focused classes
  - Better reusability and testability
  - Easier debugging and maintenance

> “A class should have only one reason to change.” — Robert C. Martin (Uncle Bob)
