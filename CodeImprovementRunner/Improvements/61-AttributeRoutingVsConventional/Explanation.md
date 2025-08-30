# 61. Attribute routing vs conventional routing

## Bad
Conventional routing:
- Relies on centralized route tables.
- Becomes fragile as routes grow.
- Harder to maintain and less explicit.

## Good
Attribute routing:
- Routes are defined directly on the endpoint (method/class).
- Self-documenting and explicit.
- Easier to reason about and reduces mistakes.

Prefer attribute routing for clarity and maintainability.
