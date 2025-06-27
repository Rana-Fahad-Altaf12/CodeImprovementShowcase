# Improvement #03: Any() vs FirstOrDefault()

## ❌ Problem

Using `FirstOrDefault()` just to check if something exists is wasteful:

```csharp
var user = db.Users.FirstOrDefault(u => u.Name == "Alice");
```
Loads full entity (and all properties)

Extra memory, CPU

Slower performance

Solution: Use Any()
```csharp
bool exists = db.Users.Any(u => u.Name == "Alice");
```
Only checks for existence

Does not load data

Translates to SQL like:

```sql
SELECT CASE WHEN EXISTS (...) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END
FROM Users WHERE Name = 'Alice'
```