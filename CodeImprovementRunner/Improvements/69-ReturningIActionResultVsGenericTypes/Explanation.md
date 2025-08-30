# 69. Returning IActionResult vs generic types

## Bad
Returning only `IActionResult`:
- Hides the actual data type.
- Clients and tools (Swagger, NSwag) can’t infer the schema.
- Makes testing and usage less type-safe.

## Good
Return `ActionResult<T>`:
- Explicitly declares the response type (`ProductDto`).
- Framework still allows returning HTTP status codes.
- Improves API documentation, client generation, and tests.

Prefer `ActionResult<T>` for clarity and type safety.
