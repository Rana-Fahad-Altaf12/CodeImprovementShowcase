# Using Nullable Reference Types in APIs

## Problem

In pre-C# 8.0 code or when nullable reference types are disabled, all reference types are implicitly nullable
— which can lead to null dereference exceptions at runtime.

### Risk in Bad Example

- `Name` is set to `null`, but no compiler warning is generated.
- Code compiles, but accessing `product.Name.Length` throws `NullReferenceException`.

## Solution

Enable nullable reference types (`#nullable enable`) and mark reference types as nullable (`string?`) explicitly.

### Benefits

- Compiler warnings for potentially unsafe null usage.
- Explicit contracts — consumers know what to expect.
- Safer and more resilient API design.

## When to Use

- Always in new APIs or projects.
- Gradually enable in legacy projects with `#nullable enable` in specific files.

## Benchmark

Not applicable — this is a compile-time safety improvement, not a runtime performance optimization.
