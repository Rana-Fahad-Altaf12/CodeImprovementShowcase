# 66. Using nullable reference types in APIs

## Bad
Without nullable reference types:
- API contracts are unclear (null may or may not be allowed).
- Leads to runtime `NullReferenceException`s.
- Consumers don’t know if a field can be missing.

## Good
With nullable reference types (`#nullable enable`):
- Clear intent: `string` = always non-null, `string?` = can be null.
- Compiler warns about missing null checks.
- Improves API reliability and consumer confidence.

Prefer explicit nullable annotations to make API contracts self-documenting.
