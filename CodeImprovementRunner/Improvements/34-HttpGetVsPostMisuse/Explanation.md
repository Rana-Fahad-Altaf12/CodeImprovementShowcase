# 34. HTTP GET vs POST Misuse

## Problem

Using `HttpGet` for operations that modify data (e.g., creating a new order) violates REST principles and HTTP semantics.

GET is meant to **retrieve** data, not perform actions that have **side effects**.

## Bad Example

```csharp
[HttpGet("create")]
public string CreateOrder([FromQuery] int productId)
```

Misuses GET for a write operation

Can be cached, pre-fetched, or logged by browsers/proxies, causing unintended duplication

Violates idempotency and safety

```csharp
[HttpPost("create")]
public string CreateOrder([FromBody] int productId)
```

Uses POST correctly for a non-idempotent operation

Communicates intent more clearly to API consumers

Complies with HTTP standards