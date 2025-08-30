# 67. Validation in controller vs middleware/filter

## Bad
Validation inside each controller/action:
- Repeated boilerplate checks.
- Risk of inconsistent rules.
- Harder to change or extend.

## Good
Centralized validation in middleware/filter:
- Keeps controller/action logic clean.
- Validation rules live in one place.
- Easier to test and maintain.

Centralize validation instead of scattering it across controllers.
