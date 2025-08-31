# Improvement #86: Newtonsoft.Json vs System.Text.Json

## Bad Example
The bad example mixes JSON libraries by serializing with `Newtonsoft.Json` and deserializing with `System.Text.Json`. This can cause:
- Compatibility issues
- Unexpected runtime errors
- Increased assembly size and memory overhead

## Good Example
The good example uses `System.Text.Json` consistently for both serialization and deserialization:
- Improved performance (faster than Newtonsoft)
- Smaller footprint
- Consistency reduces bugs and confusion

## Key Points
- Avoid mixing JSON libraries in a single project.
- Prefer `System.Text.Json` for new .NET projects unless specific Newtonsoft features are required.
- Consistent use simplifies maintenance and improves performance.
