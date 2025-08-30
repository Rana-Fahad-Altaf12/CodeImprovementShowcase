# 70. Overloaded endpoints with same route

## Bad
Using the same route for multiple parameters:
- Example: `/products/{id}` vs `/products/{name}`
- Causes ambiguity in routing.
- May result in runtime errors or wrong method execution.

## Good
Use unique, unambiguous routes:
- Add constraints (e.g., `{id:int}`).
- Use descriptive paths (`by-id`, `by-name`).
- Improves clarity, avoids conflicts, and documents intent.

Always design routes to be explicit and conflict-free.
