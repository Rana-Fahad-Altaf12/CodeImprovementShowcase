# Improvement 19 – Use var When the Type is Obvious

## Problem

This is overly verbose:

```csharp
Dictionary<string, List<int>> scores = new Dictionary<string, List<int>>();
```

Type is repeated on both sides

Adds unnecessary noise to the code

Slows down comprehension without benefit

Better Way
Use var when the type is obvious from the right-hand side:

```csharp
var scores = new Dictionary<string, List<int>>();
```

Improves readability

Keeps code DRY

Still strongly typed

Encouraged in modern C# coding standards

When to Avoid var
When the type is not obvious:

```csharp
var result = DoSomething(); // Not clear what result is
```

When clarity is more important than brevity (e.g., for public APIs)