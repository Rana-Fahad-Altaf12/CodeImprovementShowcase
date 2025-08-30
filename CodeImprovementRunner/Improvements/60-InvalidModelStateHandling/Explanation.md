# 60. Invalid model state handling

## Bad
Ignoring model state:
- Allows invalid or corrupted data into the system.
- Causes downstream bugs and inconsistent database state.
- Users see strange behavior instead of clear validation errors.

## Good
Validate model state before processing:
- Enforces correctness at the boundaries.
- Returns clear feedback when inputs are invalid.
- Keeps business logic clean by assuming valid data.

Validation should always be the first step before processing a model.
