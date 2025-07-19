# Minimize Allocations in Loops

## Bad Practice

Allocating objects or complex structures inside a loop causes:

- High memory
- GC pressure
- Slower performance in tight loops

## Good Practice

Move object instantiation outside the loop and reuse:

- Reduces unnecessary heap allocations
- Improves CPU cache efficiency
- Helps maintain predictable memory usage

## Benchmark Comparison

- Bad: Creates 100,000 new objects
- Good: Reuses a single object for all iterations
