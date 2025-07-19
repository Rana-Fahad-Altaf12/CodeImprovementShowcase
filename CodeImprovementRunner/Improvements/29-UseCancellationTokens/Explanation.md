## Use CancellationTokens

### Bad Practice

The bad example starts a long-running task with no way to cancel it.

- Consumes resources unnecessarily
- Makes the app unresponsive to user actions or shutdown signals
- Wastes CPU/memory/time in background operations

### Better Practice

The good example uses a `CancellationTokenSource` and passes its token to the task.

- Allows for cooperative cancellation
- Improves responsiveness
- Saves compute resources

### Benchmark Results

- Bad: Always runs full duration (e.g., 3000ms)
- Good: Cancels early (e.g., 100ms) if not needed

### Recommendation

Always pass a `CancellationToken` to long-running or async operations. Use `cts.CancelAfter(...)` or expose a cancel button for users to abort work gracefully.
