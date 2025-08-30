# 64. HTTP GET vs POST misuse

## Bad
Using `GET` for updates:
- Example: `/updateUser?id=42&name=John`
- Violates REST principles: GET should be safe and idempotent.
- Breaks caching and can cause unintended side effects (e.g., crawlers triggering updates).

## Good
Using `POST` (or `PUT/PATCH`) for updates:
- Example: `POST /users/42/update` with JSON body.
- Follows HTTP semantics: POST modifies state, GET retrieves data.
- Prevents accidental modifications by crawlers or caches.

Use the correct HTTP verb to match the action.
