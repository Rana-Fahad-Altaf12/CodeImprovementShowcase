# Avoid Closure Pitfalls in Loops

## Problem

Closures in loops can capture *loop variables by reference*, not by value. 
This leads to bugs where all closures refer to the final value of the variable.

### Example:
```csharp
for (int i = 0; i < 5; i++) {
    actions.Add(() => Console.WriteLine(i));
}
```
All delegates print the final i, not the one at the time of creation.

Solution
Create a local copy inside the loop:
```csharp
for (int i = 0; i < 5; i++) {
    int copy = i;
    actions.Add(() => Console.WriteLine(copy));
}
```

Why It Matters
Prevents unexpected logic bugs
Important when working with async, delegates, lambdas
Safer and more predictable loop behavior