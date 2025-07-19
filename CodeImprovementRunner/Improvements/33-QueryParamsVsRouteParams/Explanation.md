# Improvement #33: Using Query Parameters vs Route Parameters

## Overview

In RESTful APIs, the way you expose identifiers (like user IDs, order IDs, etc.) has semantic meaning.
Misusing query parameters for resource identifiers creates unclear API design and breaks conventions.

---

## The Problem with Query Parameters for Identifiers

Using query strings like `/api/users?id=42`:

- Makes the identifier feel **optional**, even if it's required.
- Violates REST conventions by treating a **resource locator** like a **filter**.
- Leads to confusing and inconsistent APIs.
- Can create problems with caching, logging, and routing.

---

## Why Route Parameters Are Better

Using route parameters like `/api/users/42`:

- Clearly identifies the **resource path**.
- Improves readability and predictability of the API.
- Aligns with REST conventions (nouns in paths).
- Makes URL routing simpler and more efficient.

---

## Real-World Impact

| Style         | URL Example              | Semantics                       |
|---------------|--------------------------|---------------------------------|
| Query Param   | `/api/products?id=10`    | Feels like a search/filter      |
| Route Param   | `/api/products/10`       | Clearly identifies one resource |

---

## Summary

Use **route parameters** when accessing a specific resource (like a user, product, or order).
Reserve **query parameters** for filters, sorts, and other optional modifiers.

- Good: `/api/users/42`
- Bad: `/api/users?id=42`
