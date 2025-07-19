# 48. Breaking Law of Demeter

## Bad: Tightly Coupled Object Chains

- Accessing `order.Customer.Address.City` breaks encapsulation
- Changes in nested classes ripple through all consumers
- Violates the **Law of Demeter**:
  > "Talk to friends, not to strangers"

## Good: Tell, Don’t Ask

- Expose methods like `GetShippingCity()` on higher-level objects
- Encapsulation preserved
- Reduces coupling, improves maintainability

## Best Practice

- Avoid long chains of method or property calls
- Prefer intention-revealing methods that delegate responsibility
- Encapsulation hides internal structure and protects from changes
