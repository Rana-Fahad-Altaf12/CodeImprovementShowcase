# Use 'as' Instead of Direct Cast (When Applicable)

## Bad Practice

Using direct cast syntax (e.g., `(string)obj`) on uncertain types can:

- Throw `InvalidCastException`
- Reduce performance due to exception handling
- Obfuscate intent when type safety isn't guaranteed

## Good Practice

Use `as` operator when:

- You're casting to a reference or nullable type
- You plan to null-check before using the value

### Advantages:
- Safer: returns `null` instead of throwing
- Faster: avoids exception overhead
- Cleaner: aligns with intent to check compatibility

## Benchmark Comparison

- Bad: Multiple `try-catch` blocks
- Good: No exceptions, just a null check
