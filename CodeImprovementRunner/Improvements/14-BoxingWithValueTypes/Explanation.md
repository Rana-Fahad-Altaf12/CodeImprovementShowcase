# Improvement 14 – Avoid Boxing with Value Types in Collections

## Problem

Using non-generic collections like `ArrayList` with value types causes **boxing**. For each value added:

```csharp
list.Add(i);  // int → object (boxed)
```

Then when reading:
```csharp
(int)item;    // object → int (unboxed)
```

Boxing allocates memory on the heap, slows performance, and increases GC pressure.

Better Approach
Use generic collections like List<int> that store value types directly:
```csharp
List<int> list = new List<int>();
```
