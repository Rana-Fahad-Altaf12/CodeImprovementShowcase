# Use Span for Slicing

## Bad Practice

Using `Substring()` for string slicing allocates a new string each time:

- Adds memory pressure
- Slows down performance in tight loops
- Causes frequent GC collections if repeated

## Good Practice

Use `Span<char>` or `ReadOnlySpan<char>`:

- Avoids allocations (zero-allocation slicing)
- Efficient for in-place processing
- Ideal for performance-critical or loop-heavy code

## Benchmark Comparison

- Bad: Allocates new strings repeatedly
- Good: Uses memory-safe, allocation-free slicing
