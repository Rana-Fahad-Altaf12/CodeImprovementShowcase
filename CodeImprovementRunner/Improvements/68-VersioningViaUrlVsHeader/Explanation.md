# 68. Versioning via URL vs header

## Bad
Using query string for versioning:
- Easy to miss or misconfigure.
- Difficult to support in caching/CDNs.
- Clutters request with non-resource parameters.

## Good
Use URL or headers for versioning:
- `/api/v1/products` is explicit and client-friendly.
- `api-version` header separates version from resource identity.
- Standard approach in REST APIs, widely supported.

Prefer URL or header versioning instead of query strings.
