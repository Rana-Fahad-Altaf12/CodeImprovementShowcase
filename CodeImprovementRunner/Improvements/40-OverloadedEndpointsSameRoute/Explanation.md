# Overloaded Endpoints with Same Route

## Problem

Defining multiple actions with the **same route** and HTTP verb but different parameters leads to:

- Routing conflicts and ambiguity
- Runtime errors or API startup failures
- Unpredictable behavior in client calls

### Example (Bad)
```csharp
[HttpGet]
public string GetUser(int id) { ... }

[HttpGet]
public string GetUser(string username) { ... } // Ambiguous
```

Solution
Use clear and unique routes with descriptive segments:

Example (Good)
```csharp
[HttpGet("by-id/{id}")]
public IActionResult GetUserById(int id) { ... }

[HttpGet("by-username/{username}")]
public IActionResult GetUserByUsername(string username) { ... }

```

Benefits
Eliminates routing conflicts

Makes API more self-descriptive and testable

Enhances Swagger/OpenAPI documentation

Supports RESTful conventions (resource-oriented)

When to Use
Always apply when method parameters differ by type or name

Especially important in public APIs or shared microservices

Performance
No performance penalty. Instead, you get more predictable, testable, and debuggable endpoints.