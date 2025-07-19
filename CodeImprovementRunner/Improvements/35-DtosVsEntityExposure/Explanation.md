# DTOs vs Entity Exposure in APIs

## Problem

Exposing your database entities directly through your API (as in the Bad example) tightly couples your internal
data model with the API contract. This makes your system brittle and exposes sensitive/internal 
fields (like `PasswordHash`) unintentionally.

## Why It's Bad

- **Security risk:** Sensitive fields might be accidentally exposed.
- **Breaking changes:** Any change in your entity affects the API.
- **Over-posting risk:** Clients could send back properties that should not be modified.
- **Tight coupling:** Database and API logic get mixed.

## Good Practice: Use DTOs

DTOs (Data Transfer Objects) act as contracts between the API and the consumer. This allows you to:

- Omit sensitive fields (like passwords, internal IDs).
- Shape the response format as needed.
- Decouple internal models from external exposure.
- Apply versioning and transformation logic easily.

## Benchmark

Not relevant for this example since it demonstrates design practice and not performance.
