Not using ILogger<T>
Problem

Many applications rely on Console.WriteLine or custom logging classes.
This causes several issues:

No structured logging (hard to query or analyze).

Sensitive data can leak into raw console outputs.

Difficult to adjust log levels across environments.

No integration with monitoring systems.

Solution

Use ILogger<T> from Microsoft.Extensions.Logging:

Provides structured, parameterized logging.

Supports log levels (Trace, Debug, Information, Warning, Error, Critical).

Integrates with providers (Console, Debug, Seq, Application Insights, ELK).

Avoids leaking sensitive information by enforcing patterns.

Benefits

Consistent and structured logging.

Environment-based configuration for log levels.

Easy integration with observability tools.

Improved debugging, monitoring, and security posture.