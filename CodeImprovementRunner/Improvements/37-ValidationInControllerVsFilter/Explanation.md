# Validation in Controller vs Middleware/Filter

## Problem

Placing validation logic directly inside controllers leads to:

- Repetition across multiple methods or controllers.
- Difficulty in testing validations independently.
- Violation of Single Responsibility Principle (SRP).

## Solution

Move validation logic into reusable filters or middleware.

## Benefits

- Reusability across different endpoints or controllers.
- Cleaner controller code.
- Improved testability and separation of concerns.

## When to Use

- For input validation in APIs (e.g., DTO checks).
- Complex scenarios can benefit from middleware pipelines or Action Filters (in ASP.NET Core).
- Consider `FluentValidation` or custom `ActionFilterAttribute` for extensibility.

## Benchmark

This is a **maintainability improvement**, not a performance one. Though it may slightly reduce duplication and logic nesting.
