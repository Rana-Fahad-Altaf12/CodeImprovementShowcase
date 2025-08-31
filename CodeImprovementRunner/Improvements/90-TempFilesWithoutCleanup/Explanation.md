# Improvement #90: Temp Files Without Cleanup

## Bad Example
The bad example creates temporary files without deleting them:
- Temporary files accumulate over time
- Can consume disk space and cause maintenance issues
- Unsafe for sensitive data

## Good Example
The good example ensures cleanup using `finally`:
- Temporary files are safely deleted
- Reduces disk usage and security risks
- Cleaner and more maintainable

## Key Points
- Always clean up temporary files after use.
- Consider using `using` blocks or `try/finally` to guarantee deletion.
- Prevents potential disk space exhaustion and security issues.
