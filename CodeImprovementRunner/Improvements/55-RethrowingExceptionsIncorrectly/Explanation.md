# 55. Rethrowing Exceptions Incorrectly

## Bad: `throw ex;`
Using `throw ex;` rethrows the exception but **resets the stack trace**.  
This makes debugging much harder, since you lose the original point where the error occurred.

Example output stack trace with `throw ex;`:

System.InvalidOperationException: Something went wrong!
at Improvements._55_RethrowingExceptions.Bad.RethrowWithEx.Run()

Notice the original method `CauseError` is missing from the trace.

---

## Good: `throw;`
Using `throw;` rethrows the exception **without altering the stack trace**.  
This preserves the original error location, making debugging far easier.

Example output stack trace with `throw;`:

System.InvalidOperationException: Something went wrong!
at Improvements._55_RethrowingExceptions.Good.RethrowWithThrow.CauseError()
at Improvements._55_RethrowingExceptions.Good.RethrowWithThrow.Run()


---

## Summary
- `throw ex;` = stack trace lost, harder debugging.
- `throw;` = original stack trace preserved.
