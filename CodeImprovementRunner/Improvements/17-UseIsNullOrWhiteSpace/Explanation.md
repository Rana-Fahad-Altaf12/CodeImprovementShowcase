# Improvement 17 – Use string.IsNullOrWhiteSpace Instead of Manual Null/Empty Checks

## Problem

Manual string checks often look like this:

```csharp
if (name != null && name.Trim() != "")
```

Issues:

Repetitive and verbose

Easy to forget .Trim() or null check

Doesn’t handle whitespace-only strings well

Harder to read

Better Way
Use built-in helper:
```csharp
if (!string.IsNullOrWhiteSpace(name))
```

Handles null, empty string, and whitespace

Readable and concise

Less chance of subtle bugs

Standardizes validation logic