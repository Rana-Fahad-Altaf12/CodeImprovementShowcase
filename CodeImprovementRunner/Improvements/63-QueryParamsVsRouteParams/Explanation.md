# 63. Using Query Params vs Route Params

## Bad
Placing identifiers in query parameters:
- `GET /products/details?id=42`
- Less readable.
- Not RESTful, mixes resource identity with filtering.

## Good
Using route parameters:
- `GET /products/42`
- Clean, RESTful, and intuitive.
- Represents resources properly.

Query parameters should be reserved for filters, paging, or optional data, not resource identity.
