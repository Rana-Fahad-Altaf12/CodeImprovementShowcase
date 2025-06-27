# Improvement #02: IEnumerable vs IQueryable

## Problem with IEnumerable

In the bad example, we use:

```csharp
var allUsers = _context.Users.ToList(); // pulls ALL rows into memory
```

Correct Approach: Use IQueryable
In the good example, we write:

```csharp
_context.Users
    .Where(u => u.Name.StartsWith("A"))
    .Select(u => u.Name)
    .ToList();
```

This translates to SQL:
```sql
SELECT Name FROM Users WHERE Name LIKE 'A%'
```
So the database does the heavy work, not your app.