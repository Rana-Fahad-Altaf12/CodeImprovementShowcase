# Improvement 11 – Use StringBuilder Instead of String Concatenation

## Problem

In C#, strings are immutable. Every time you use `+=` or `+`, a **new copy** of the string is created.

```csharp
string result = "";
for (int i = 0; i < 50000; i++)
{
    result += "x"; // new string every time
}
```

This results in:

Huge memory overhead (O(n²) behavior)

Unnecessary CPU allocations

Garbage collection pressure

Solution
Use StringBuilder, which efficiently appends to an internal buffer.

```csharp
var sb = new StringBuilder();
for (int i = 0; i < 50000; i++)
{
    sb.Append("x");
}
string result = sb.ToString();
```

When to Use
Always prefer StringBuilder for string construction in loops or large text processing.

Regular + is okay for 1-2 small string merges.

While StringBuilder may show higher final memory in GC.GetTotalMemory(), it allocates far less overall, 
executes hundreds of times faster, and avoids excessive garbage collection. 
Always prefer it for large string operations in loops.