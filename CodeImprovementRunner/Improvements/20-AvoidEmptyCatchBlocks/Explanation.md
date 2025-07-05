# Improvement 20 – Avoid Empty Catch Blocks

## Problem

This is dangerous:

```csharp
try
{
    // risky code
}
catch
{
    // silence
}
```

Hides all exceptions (including fatal ones)

Makes bugs hard to trace

Can cause inconsistent behavior

Violates defensive coding principles

Better Approach
Catch only what you intend to handle:

```csharp
try
{
    int x = int.Parse("invalid");
}
catch (FormatException ex)
{
    Console.WriteLine($"Handled: {ex.Message}");
}
```

Why It's Better
Makes errors visible

Allows fallback or recovery logic

Improves maintainability

Prevents silent failures in production