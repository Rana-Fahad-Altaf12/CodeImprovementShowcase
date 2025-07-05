# Improvement 12 – Avoid `Where().FirstOrDefault()` When Predicate Can Be Used Directly

## Problem

Using both `Where(...)` and `FirstOrDefault()` together is redundant and less efficient:

```csharp
var user = users.Where(u => u.Id == 42).FirstOrDefault();
```

This causes:

Two LINQ operations

Potential extra allocations

Reduced readability

Better Approach
Use FirstOrDefault with a predicate directly:
```csharp
var user = users.FirstOrDefault(u => u.Id == 42);
```

Why It’s Better
Single pass iteration

Avoids intermediate IEnumerable

Clearer intent