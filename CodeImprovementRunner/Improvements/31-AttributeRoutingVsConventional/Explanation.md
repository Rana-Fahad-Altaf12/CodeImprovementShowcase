# Improvement 31 – Attribute Routing vs Conventional Routing

## Bad: `ConventionalRoutingExample`
Conventional routing relies on predefined route templates like `{controller}/{action}/{id?}` in `Startup.cs`. 
While it works for simple setups, it becomes hard to maintain and modify for large APIs, 
especially when versioning or custom URIs are required.

**Drawbacks:**
- Implicit and centralized route mapping.
- Difficult to see route behavior in the controller itself.
- Fragile with renaming controllers or actions.

## Good: `AttributeRoutingExample`
Attribute routing allows you to define routes directly on controller and action methods using `[Route]`, `[HttpGet]`, etc.

**Benefits:**
- Clear route definition near the action.
- Supports custom, RESTful, and versioned paths.
- Easier to reason about and maintain.