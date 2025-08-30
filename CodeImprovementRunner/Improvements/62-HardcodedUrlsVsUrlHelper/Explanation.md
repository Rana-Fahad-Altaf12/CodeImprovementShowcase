# 62. Hardcoded URLs vs IUrlHelper

## Bad
Hardcoding URLs:
- Creates brittle code (changes in routes require updates everywhere).
- Harder to test and maintain.
- Prone to typos and inconsistencies.

## Good
Using a URL helper:
- Centralizes URL generation.
- Automatically adapts to route changes.
- Cleaner, maintainable, and reduces mistakes.

Always prefer helpers (like `IUrlHelper`) instead of hardcoded strings.
