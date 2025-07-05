# Improvement 16 – Use TryGetValue Instead of ContainsKey + Indexer

## Problem

The following code is inefficient:

```csharp
if (dict.ContainsKey("admin"))
{
    var role = dict["admin"];
}
```

It does two lookups:

ContainsKey("admin")

dict["admin"]

This is redundant and wastes CPU cycles

Especially costly inside loops

Better Way
Use TryGetValue:
```csharp
if (dict.TryGetValue("admin", out var role))
{
    // Use role
}
```

Single lookup

Cleaner and faster

Safer when accessing unknown keys