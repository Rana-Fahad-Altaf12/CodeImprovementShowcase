# 42. Unit of Work Implementation

## Bad: DirectDbContextCalls
- DbContext operations are called multiple times separately.
- Each call to `SaveChanges()` is its own transaction.
- No guarantee that all steps complete together.
- Error midway causes partial persistence — **data integrity risk**.

## Good: UnitOfWorkUsage
- All changes are managed by a Unit of Work.
- `Complete()` commits changes in one transaction.
- Encourages **transaction consistency** and **single responsibility**.
- Helps maintain a cleaner and testable domain-driven design.

## Why It Matters
- In real-world apps, persisting multiple entities often requires atomic transactions.
- Unit of Work pattern groups operations together to avoid partial saves.
