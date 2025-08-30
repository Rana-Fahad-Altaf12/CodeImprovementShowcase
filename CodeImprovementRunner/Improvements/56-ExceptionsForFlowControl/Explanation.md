# 56. Exceptions for Flow Control

## Bad: Using exceptions as normal conditions
Exceptions should be used **only for exceptional cases**, not as a substitute for `if` checks or loop control.

In the bad example, finding a number in a list is treated as an "exception".  
This has drawbacks:
- Performance hit (throwing/catching exceptions is slow).
- Memory overhead from stack trace allocation.
- Makes code harder to read and misleading.

Output example:
Bad Result = 4
Time: 1500 ticks
Memory: +4096 bytes

---

## Good: Use proper control flow
Normal conditions (like checking if an item exists) should be handled with:
- `if` statements
- loops
- LINQ (`FirstOrDefault`, `Any`, etc.)

This keeps code **clearer, faster, and more predictable**.

Output example:
Good Result = 4
Time: 25 ticks
Memory: +0 bytes

---

## Summary
- Exceptions for flow control = misuse, slow, misleading.  
- Use conditional logic for expected scenarios, reserve exceptions for *unexpected failures*.
