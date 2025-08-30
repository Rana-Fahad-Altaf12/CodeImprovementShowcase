# 58. Logging inside catch vs bubbling up

## Bad
Logging inside every catch block causes:
- Duplicate logs for the same exception.
- Harder log analysis due to noise.
- Mixing of concerns (business logic + logging everywhere).

## Good
Let exceptions bubble up and log once:
- Log at application/service boundaries.
- Internal methods should throw exceptions, not log them.
- This reduces noise, improves clarity, and follows separation of concerns.

Log once at the right level, not everywhere.
