# Returning IActionResult vs Generic Types

## Problem

Returning raw types like `string`, `User`, or `List<T>` from controller actions:

- Lacks flexibility for different HTTP responses.
- Can't return error codes or status messages.
- Makes it harder to handle errors and validation consistently.

## Solution

Return `IActionResult` (or `ActionResult<T>` in ASP.NET Core):

```csharp
public IActionResult GetUser(int id)
{
    if (id <= 0)
        return NotFound();
    return Ok(user);
}
```

Benefits
Enables custom status codes (200, 404, 400, 500, etc).
Easier to test and extend.
Better support for content negotiation (e.g., JSON vs XML).
Integrates better with Swagger/OpenAPI.

When to Use
Always use IActionResult or ActionResult<T> in real-world REST APIs.

Only return raw types in demo projects or where APIs are tightly controlled and never expected to evolve.

Real-world Example
In ASP.NET Core, this is the standard pattern for controllers:

```csharp
[HttpGet("{id}")]
public ActionResult<User> GetUser(int id)
{
    var user = _repo.Find(id);
    if (user == null) return NotFound();
    return Ok(user);
}
```

Performance Note
Minimal overhead compared to returning raw types.

Gains in maintainability and flexibility far outweigh any minor cost.
