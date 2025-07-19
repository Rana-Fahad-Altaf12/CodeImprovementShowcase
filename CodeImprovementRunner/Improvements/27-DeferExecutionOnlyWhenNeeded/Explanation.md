# Defer Execution Only When Needed

## Problem

LINQ uses deferred execution by default. This means queries aren't run until they're enumerated.

If you enumerate the same LINQ query multiple times (e.g., for Count, Max), it reruns each time.

### Example:

```csharp
var evens = numbers.Where(n => n % 2 == 0); // not evaluated yet
int count = evens.Count(); // runs now
int max = evens.Max();     // runs again
```

This causes performance loss and risk of inconsistency if the data source changes between evaluations.

Solution
Materialize the query result when you need to reuse it:
```csharp
var evens = numbers.Where(n => n % 2 == 0).ToList();
int count = evens.Count;
int max = evens.Max();
```

When to Materialize
When the query is expensive (database, network, CPU-heavy)

When you access the result multiple times

When you want snapshot consistency

When Not to Materialize
When you only use it once

When the source is already materialized (e.g., arrays/lists)