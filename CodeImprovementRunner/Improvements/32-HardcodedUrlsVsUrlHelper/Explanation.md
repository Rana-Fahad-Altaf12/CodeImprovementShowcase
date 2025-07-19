# Improvement #32: Hardcoded URLs vs IUrlHelper

## Overview

Hardcoding URLs inside your application — especially in controllers, services, or clients — is a common 
but dangerous anti-pattern. Instead of manually constructing URLs like `"https://example.com/api/users/42/profile"`, 
you should use `IUrlHelper` (or similar abstractions) provided by ASP.NET Core to generate URLs dynamically.

---

## The Problem with Hardcoded URLs

When you hardcode URLs:

- You tightly couple your code to specific route templates.
- You increase the risk of broken links during refactors or route version changes.
- You violate the DRY (Don't Repeat Yourself) principle — duplicating base URLs and paths across classes.
- You lose out on features like API versioning, localization, and routing conventions.

This approach leads to brittle, hard-to-maintain codebases, especially in large applications with evolving API endpoints.

---

## Why `IUrlHelper` Is Better

`IUrlHelper` is a built-in service in ASP.NET Core that generates URLs based on your application's routing configuration. 
It uses your controller/action names and route parameters to create accurate URLs that automatically adapt to any route
changes.

### Benefits:
- **Centralized URL logic**: Refactors in one place update all consumers.
- **Strong typing**: Uses controller/action names instead of raw strings.
- **Route awareness**: Adapts to attribute routing, default routes, or custom templates.
- **Supports versioning and localization**: Route-based versions or language segments are respected.

---

## Real-World Example

Imagine this route in your controller:

```csharp
[Route("api/users/{userId}/profile")]
public IActionResult Profile(int userId) => ...
```