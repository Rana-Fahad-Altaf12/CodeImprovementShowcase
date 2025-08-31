# 81. Serializing entire objects vs DTOs

## Bad
- Serializing entire domain objects.
- Exposes sensitive data like passwords or internal properties.
- Hard to maintain and may leak more data than intended.

## Good
- Serialize only a DTO with required fields.
- Keeps sensitive data safe and limits output to necessary information.
- Easier to maintain and evolves independently from domain objects.

Always use DTOs when exposing data externally instead of serializing full domain entities.
