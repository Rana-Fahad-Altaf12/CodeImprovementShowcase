## 79. Poor modular boundaries in monoliths

**Bad:**  
- Services directly depend on each other  
- High coupling, difficult to maintain or test  

**Good:**  
- Each module has clear boundaries  
- Use DTOs or return objects to decouple services  
- Improves maintainability, testability, and readability
