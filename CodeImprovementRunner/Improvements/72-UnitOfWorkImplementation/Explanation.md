### 72 – Unit of Work Implementation

**Bad (Direct Repository Usage)**  
- Each repository call commits independently.  
- No shared transaction context, making rollback impossible.  
- Leads to inconsistent state if one operation fails.

**Good (Unit of Work Pattern)**  
- Provides a single transaction boundary.  
- Multiple repository operations can be committed/rolled back together.  
- Reduces risk of data inconsistency.  
- More efficient resource handling.

Use Unit of Work when you need transaction consistency across multiple repositories.
