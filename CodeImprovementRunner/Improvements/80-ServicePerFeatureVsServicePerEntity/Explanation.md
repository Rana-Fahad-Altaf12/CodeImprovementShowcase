## 80. Service per feature vs service per entity

**Bad:**  
- One service per entity leads to fragmented operations  
- Multiple services must be orchestrated externally  
- More boilerplate, harder to maintain  

**Good:**  
- Service-per-feature groups all steps of a feature  
- Single entry point for operations  
- Improves maintainability, readability, and reduces boilerplate
