# 57. Ignoring task exceptions (unobserved)

## Bad
Starting background tasks without awaiting or observing exceptions causes:
- Exceptions being swallowed silently.
- Possible process termination if `TaskScheduler.UnobservedTaskException` is raised.
- Debugging difficulty, as failures disappear without logs.

## Good
Always observe exceptions:
- Use `await` in async methods.
- If synchronous, call `.Wait()` or `.GetAwaiter().GetResult()`.
- Catch and log exceptions explicitly.
- For fire-and-forget, attach `ContinueWith` to log failures.

This ensures reliability and makes debugging easier.
