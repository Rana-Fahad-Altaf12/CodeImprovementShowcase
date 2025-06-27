# Improvement #7: Use .Contains() instead of multiple OR conditions

## Problem

Using multiple `OR` conditions:

```csharp
.Where(u => u.Name == "Alice" || u.Name == "Bob" || u.Name == "Charlie")
```

Becomes hard to maintain as conditions grow

Makes query harder to read

Performs slightly worse in EF Core translation

Solution
Use .Contains():

```csharp
var names = new[] { "Alice", "Bob", "Charlie" };
.Where(u => names.Contains(u.Name))
```

Cleaner and more readable

Easier to scale dynamically

Compiles down efficiently by EF Core