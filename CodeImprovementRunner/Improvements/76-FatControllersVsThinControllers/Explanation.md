## 76. Fat controllers vs thin controllers

**Bad:**  
- Controller handles validation, business logic, database updates, email, and logging  
- Hard to maintain and test  
- Violates separation of concerns  

**Good:**  
- Controller delegates responsibilities to dedicated services  
- Validation, order processing, email, and logging are separated  
- Controller becomes thin and maintainable
