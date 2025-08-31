# 83. Storing config in code vs appsettings

## Bad
- Hardcoded configuration values.
- Requires code changes to update settings.
- Not environment-friendly (dev, test, prod).

## Good
- Uses appsettings.json for configuration.
- Easy to change settings without modifying code.
- Supports environment-specific overrides and better maintainability.

Always store environment-dependent values in configuration files instead of hardcoding them.
