# Improvement #6: Avoid Select(x => new { x.Prop }) when projecting same data

## Problem

Writing this:

```csharp
var names = db.Users
    .Select(x => new { x.Name })
    .Select(a => a.Name)
    .ToList();
```

Creates unnecessary anonymous objects

Consumes more memory

Adds extra IL instructions

Breaks EF Core tracking

Solution
Use direct projection instead:

```csharp
var names = db.Users
    .Select(x => x.Name)
    .ToList();
```

This is more efficient and preserves EF behavior.
