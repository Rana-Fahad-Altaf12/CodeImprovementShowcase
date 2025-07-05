# Improvement 18 – Avoid Unnecessary async/await

## Problem

This is a common inefficiency:

```csharp
public async Task<int> GetValueAsync()
{
    return await Task.FromResult(42);
}
```

This:

Compiles into a full state machine

Introduces unnecessary overhead

Increases memory footprint

Adds complexity to stack traces and debugging

Better Way
If you're simply wrapping a result:

```csharp
public Task<int> GetValueAsync()
{
    return Task.FromResult(42);
}
```

No async state machine

More efficient

Same external behavior

This pattern is especially useful in library or DAL layers returning cached or default data.