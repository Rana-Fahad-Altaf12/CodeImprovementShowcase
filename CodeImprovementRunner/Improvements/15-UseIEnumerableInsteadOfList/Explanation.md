# Improvement 15 – Prefer `IEnumerable<T>` over `List<T>` for Read-Only Access

## Problem

Returning `List<T>` for read-only operations:
- Exposes the actual collection
- Allows accidental mutation
- Reduces abstraction and testability
- Forces implementation to be eagerly evaluated

Example:
```csharp
public List<string> GetNames() { return ... }
```

This ties the caller to the fact you're using a list.

Solution
Return IEnumerable<T>:

```csharp
public IEnumerable<string> GetNames() { yield return ... }
```

Promotes read-only access

Supports deferred execution (lazy evaluation)

Easier to refactor the implementation later

Encourages programming to interface