## Avoid Excessive Logging

### Bad Practice

The bad implementation logs every iteration's message directly to the console, regardless of whether debug logging is needed or not.

This:
- Floods the output
- Drastically increases execution time
- Adds significant I/O overhead
- Obscures meaningful logs in production

### Better Practice

The good implementation uses a condition (`isDebugEnabled`) to toggle logging.

This:
- Avoids unnecessary I/O during normal execution
- Allows enabling logs only when needed (e.g., local dev or troubleshooting)
- Improves performance drastically for large loops

### Benchmark Results

- Bad: ~6000ms and 15-25MB memory depending on console buffer
- Good: ~1ms and 0.1MB memory

### Recommendation

Always use conditional logging or structured logging frameworks that support log levels (`Debug`, `Info`, `Warn`, etc.). Avoid flooding logs in high-frequency code paths like loops or multithreaded tasks.
