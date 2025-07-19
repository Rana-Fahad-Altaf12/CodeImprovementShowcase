## Avoid Large Object Heap (LOH)

### Bad Practice

Allocating arrays or objects larger than 85,000 bytes causes them to be placed on the Large Object Heap (LOH). 
Objects in the LOH are not compacted during garbage collection, leading to:

- Fragmentation
- Higher memory pressure
- Less predictable performance

### Good Practice

Use `ArrayPool<T>` for temporary large buffers. It reduces allocations and avoids LOH by pooling arrays:

- Improves memory reuse
- Reduces GC pressure
- Prevents LOH fragmentation

### Benchmarks

- [Bad] LOH Allocation: Slower and may increase memory fragmentation.
- [Good] ArrayPool: Faster and avoids persistent LOH usage.

> Avoid LOH unless absolutely necessary — use pooling or break large allocations into smaller chunks if possible.
