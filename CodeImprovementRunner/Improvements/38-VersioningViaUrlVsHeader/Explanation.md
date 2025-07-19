# Versioning via URL vs Header

## Problem

Using custom headers for API versioning:

- Hides versioning from the URI.
- Makes debugging/troubleshooting harder (version is not visible in logs or browser).
- Requires custom middleware or header inspection.

## Solution

Use URL-based versioning:

- `/api/v1/resource`
- `/api/v2/resource`

## Benefits

- Easier to discover and debug.
- Standardized and REST-compliant.
- Supported natively in most API gateways, documentation tools, and routing systems.

## When to Use

- URL versioning: For public APIs or those that evolve visibly.
- Header versioning: Only when strict adherence to REST HATEOAS is required or you want versioning completely 
- abstracted (internal systems).

## Real-world Example

- GitHub, Azure, Stripe, and many others use URL-based versioning for clarity and simplicity.

## Benchmark

This is primarily a **design and usability improvement**, not about performance.
