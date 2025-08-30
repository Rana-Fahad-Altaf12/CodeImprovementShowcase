## 78. Breaking Law of Demeter

**Bad:**  
- Chaining multiple object properties (`order.Customer.Address.City`)  
- Tight coupling, difficult to maintain  

**Good:**  
- Expose methods/properties that hide internal structure  
- Call `order.GetCustomerCity()` instead of chained access  
- Adheres to Law of Demeter, improves encapsulation
