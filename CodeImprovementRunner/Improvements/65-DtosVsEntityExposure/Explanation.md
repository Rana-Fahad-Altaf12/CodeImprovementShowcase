# 65. DTOs vs Entity exposure

## Bad
Exposing entities directly:
- Leaks sensitive/internal fields (e.g., password hashes, internal IDs).
- Couples API to database schema.
- Harder to evolve API without breaking clients.

## Good
Using DTOs (Data Transfer Objects):
- Only expose safe and relevant fields.
- Decouples API from database.
- Allows shaping responses for client needs (projections, renaming).

Always map entities , DTOs before returning from APIs.
