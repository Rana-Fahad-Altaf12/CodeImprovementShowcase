# Improvement #5: Avoid multiple `.ToList()` calls

## Problem

Calling `.ToList()` multiple times in a LINQ pipeline breaks deferred execution and causes performance and memory issues.

```csharp
var users = db.Users.ToList();
var filtered = users.Where(u => u.Name == "Alice").ToList();
var names = filtered.Select(u => u.Name).ToList();
```
This materializes the data three times and shifts filtering and projection to memory instead of the database.

Solution
Use a single .ToList() at the end of the query chain:

```csharp
var names = db.Users
    .Where(u => u.Name == "Alice")
    .Select(u => u.Name)
    .ToList();
```

This keeps filtering and projection in the database, reducing memory usage and CPU time.
