## 75. Violating SRP in services

**Bad:**  
- One service handles validation, payment, and email  
- Hard to test and maintain  
- Violates Single Responsibility Principle  

**Good:**  
- Split responsibilities into separate services  
- OrderValidator, PaymentProcessor, EmailSender  
- Each class has a single, testable responsibility
