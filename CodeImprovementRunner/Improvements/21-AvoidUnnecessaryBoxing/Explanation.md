# Improvement #21: Avoid Unnecessary Boxing

## Bad Practice

Boxing occurs when a value type (like int) is converted to a reference type such as object or any interface it implements:

```csharp
object boxedValue = 42;           // Boxing
int unboxed = (int)boxedValue;   // Unboxing
```

Why it's bad:

Allocates memory on the heap
Triggers garbage collection pressure
Slows down performance, especially in tight loops or large data sets

Good Practice
Avoid boxing by using value types directly and leveraging generics:

```csharp
int value = 42;
int copy = value; // No boxing
```

ou can also avoid boxing by:

Using generic collections (List<T>, Dictionary<TKey, TValue>)

Avoiding interface-based access when working with structs

Declaring variables with value types instead of object

Performance Impact
Boxing may seem harmless in small examples, but in performance-critical paths (e.g., loops, data processing), it adds overhead.

Comparison:

Code							Allocation Type
object val = 42					Heap (boxed)
int val = 42					Stack (no boxing)

Summary
Avoid boxing unless necessary, especially in performance-sensitive applications or large data structures. Use generics and strong typing wherever possible.
