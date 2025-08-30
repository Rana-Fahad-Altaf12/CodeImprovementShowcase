## 74. Domain services vs application services

**Bad:**  
- Business logic is mixed into application services  
- Hard to test, reuse, or maintain  
- Violates separation of concerns  

**Good:**  
- Domain services contain business rules  
- Application services orchestrate domain services  
- Cleaner, testable, and maintainable architecture
