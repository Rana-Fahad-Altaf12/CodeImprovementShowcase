# Improvement 13 – Avoid .ToList() Before .Any()

## Problem

This is a common mistake:

```csharp
var list = users.Where(u => u.IsActive).ToList();
if (list.Any()) { ... }
```

What’s wrong?

You're materializing the full result just to check if any match

This can be very wasteful with large datasets

Especially bad with EF — it translates to full SQL data pull

Better Way
```csharp
if (users.Any(u => u.IsActive)) { ... }
```

Benefits
Short-circuits on first match

No list allocation

Translates to efficient SQL EXISTS in EF