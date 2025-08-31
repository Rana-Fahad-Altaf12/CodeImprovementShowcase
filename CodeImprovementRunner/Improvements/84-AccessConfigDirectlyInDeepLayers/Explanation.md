# 84. Accessing config directly in deep layers

## Bad
- Deep layers directly access configuration.
- Hard to test and tightly coupled to configuration source.
- Violates dependency inversion principle.

## Good
- Inject configuration into classes via DI or static config holder for demo.
- Keeps layers decoupled and testable.
- Changes to configuration source do not require modifying deep layers.

Always inject configuration into services rather than accessing files directly in business logic.
