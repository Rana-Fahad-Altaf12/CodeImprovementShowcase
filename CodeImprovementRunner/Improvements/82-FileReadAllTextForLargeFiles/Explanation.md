# 82. Using File.ReadAllText for large files

## Bad
- Loads entire file into memory at once.
- Risk of OutOfMemoryException with very large files.
- Inefficient for streaming or processing line by line.

## Good
- Reads file using a stream line by line.
- Memory usage is constant regardless of file size.
- More efficient and safer for large files.

Always prefer streaming for large files instead of reading everything into memory at once.
