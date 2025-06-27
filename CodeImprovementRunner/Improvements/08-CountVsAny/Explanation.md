# Improvement #8: Use Any() instead of Count() > 0

## Problem

This is common but inefficient:

```csharp
if (db.Users.Where(u => u.Name == "Alice").Count() > 0)
```

Fetches and counts all matching rows

Slower for large datasets

Poorer SQL translation

Solution
Use .Any():

```csharp
if (db.Users.Any(u => u.Name == "Alice"))
```
Stops at first match

Translates to efficient SELECT TOP 1 ...

Saves CPU and memory