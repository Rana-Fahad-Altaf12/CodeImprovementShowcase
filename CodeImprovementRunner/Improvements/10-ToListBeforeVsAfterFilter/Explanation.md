# Improvement #10: Move .ToList() After Filtering

## Problem

Using `.ToList()` before filtering:

```csharp
users.ToList().Where(x => x.Name == "Alice").ToList();
```

Loads entire list into memory.

Wasteful if only a small portion is needed.

Slower and higher memory consumption.

Better
Filter first, then convert to list:

```csharp
users.Where(x => x.Name == "Alice").ToList();
```

Filters are executed on-demand.

Only necessary items are materialized.

Saves time and memory.