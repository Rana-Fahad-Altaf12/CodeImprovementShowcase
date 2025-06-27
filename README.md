# Code Improvement Showcase (.NET)

This repository contains 100+ small and focused C#/.NET code improvement examples — each with:

- A **bad implementation**
- A **good implementation**
- A clear, **measurable explanation** (performance, memory, correctness)
- Runnable side-by-side in console with live benchmarks

---

## ✅ Why I Built This

While working on a secure file sharing system, I realized I often spot patterns that **look right but are inefficient**, e.g.:

- Using `.ToList()` before `.Where()`
- Misusing `FirstOrDefault()` when `Any()` is better
- Registering `DbContext` as Singleton

I wanted to break this into **small, testable chunks**, where each example:
- Teaches one thing
- Proves why it's better
- Can be demonstrated in isolation

---

## 🛠️ How It Works

Each improvement is inside its own folder under `/Improvements`, e.g.:

Improvements/
01_DbContextLifetime/
02_IEnumerableVsIQueryable/
03_AnyVsFirstOrDefault/


Each folder includes:
- `/Bad/` – inefficient code
- `/Good/` – improved code
- `Explanation.md` – the why behind it

Run it using the CLI:

```bash
dotnet run --project CodeImprovementRunner
```

🔍 Improvements Covered So Far
| ID | Title                                     |
| -- | ----------------------------------------- |
| 01 | Singleton vs Scoped DbContext             |
| 02 | IEnumerable vs IQueryable                 |
| 03 | Any vs FirstOrDefault                     |
| 04 | Result vs Await                           |
| 05 | Multiple .ToList() vs Chained LINQ        |
| 06 | Unnecessary Select projection             |
| 07 | OR conditions vs .Contains()              |
| 08 | Count() > 0 vs Any()                      |
| 09 | FirstOrDefault vs Any() (existence check) |
| 10 | ToList before vs after filter             |

🚀 What’s Next
I’ll be adding more improvements over time, including:

HashSet vs List for lookup
Dictionary misuse patterns
Caching improvements
API routing and filtering best practices
Design pattern misuse examples
Memory profiling

Stay tuned!

🤝 Contributing
Suggestions? PRs? Bug reports? Let’s make this a community-driven effort!