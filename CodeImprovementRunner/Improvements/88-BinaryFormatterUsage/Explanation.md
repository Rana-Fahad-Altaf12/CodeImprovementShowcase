# Improvement #88: BinaryFormatter Usage

## Bad Example
The bad example uses `BinaryFormatter` for serialization:
- BinaryFormatter is insecure and can lead to remote code execution vulnerabilities
- Not recommended in .NET 5+ (marked obsolete)
- Harder to debug and maintain

## Good Example
The good example uses `System.Text.Json` for safe serialization:
- Safe and modern
- Cross-platform and readable
- Works well with APIs and logs

## Key Points
- Avoid `BinaryFormatter` completely; use `System.Text.Json` or other safe serializers like `XmlSerializer` or `DataContractSerializer` if needed.
- JSON provides security, maintainability, and interoperability benefits.
