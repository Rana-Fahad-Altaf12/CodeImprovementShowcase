# 43. Specification Pattern

## Bad: HardcodedFilterLogic
- Filtering logic is written inline using `.Where()` with combined conditions.
- Hard to test and reuse.
- Any change in criteria requires changes in multiple places.
- Becomes harder to maintain with complex filters.

## Good: SpecificationPatternUsage
- Filtering logic is encapsulated in a reusable `ISpecification<T>` class.
- Promotes single responsibility and separation of concerns.
- Easy to test individual specifications.
- Composable and extendable for complex logic (e.g., combining with AND/OR specs).

## Why It Matters
- Specification pattern helps model business rules explicitly.
- Promotes **clean architecture**, **testability**, and **reusability**.
- Ideal for domain-driven design and querying complex data in repositories.

