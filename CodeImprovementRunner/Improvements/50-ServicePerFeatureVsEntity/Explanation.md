# 50. Service per Feature vs Service per Entity

## Bad: Service per Entity

- Logic split across `OrderService`, `CustomerService`, etc.
- Leads to **anemic services** and **transactional logic spread**
- Requires orchestration logic in controllers or external coordinators

## Good: Service per Feature

- One service handles complete use-case (`OrderPlacementService`)
- Logic is **cohesive**, **focused**, and **testable**
- Easier to maintain and reason about
- Reduces back-and-forth dependencies

## Best Practice

- Organize services around **business use-cases**, not just entities
- Let features drive service boundaries (e.g., `CheckoutService`, `RefundService`)
- Keep orchestration logic inside domain/application layer, not controllers
