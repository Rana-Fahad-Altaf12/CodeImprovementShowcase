# Improvement #9: Use Any() Instead of FirstOrDefault() != null

## Problem

Using `FirstOrDefault()` like this:

```csharp
if (db.Users.Where(x => x.Name == "Alice").FirstOrDefault() != null)
```

Fetches the entire entity

Wastes memory and CPU if you don’t need the object

Results in less efficient SQL

Better

```csharp
if (db.Users.Any(x => x.Name == "Alice"))
```

Stops after finding first match

Returns true/false directly

Translates to SELECT 1 WHERE EXISTS(...) in SQL