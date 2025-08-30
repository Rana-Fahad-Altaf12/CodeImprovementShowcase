# 52. Logging Sensitive Data

## Bad Practice
The bad example logs **raw sensitive information** (like passwords) when an exception occurs:

```csharp
Console.WriteLine($"Login failed for user={username}, password={password}, error={ex.Message}");
```
This is dangerous because:

Sensitive data may leak into log files.

Logs are often accessible to support teams, developers, or even external systems.

Violates security compliance standards (e.g., GDPR, PCI DSS).

**Good Practice**


Instead of logging passwords or personal information, only log safe contextual details:

```csharp
Console.WriteLine($"Login failed for user={username}, error={ex.Message}");
```

Benefits:

Prevents accidental leaks of credentials.

Keeps logs useful without exposing sensitive data.

Meets security compliance requirements.
