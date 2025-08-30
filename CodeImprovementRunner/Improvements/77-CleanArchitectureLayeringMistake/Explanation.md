## 77. Clean architecture layering mistake

**Bad:**  
- UI layer directly accesses repository  
- Bypasses application/service layer  
- Tight coupling and hard to maintain  

**Good:**  
- UI interacts with application/service layer only  
- Service layer handles business logic and data access  
- Clean separation of concerns and easier to test
