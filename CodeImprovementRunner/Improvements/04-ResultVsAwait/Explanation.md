# Improvement #4: .Result / .Wait() vs await

## The Problem with .Result / .Wait()

```csharp
var data = service.GetDataAsync().Result;
```

This blocks the calling thread. In a console app it might "work", but:

In ASP.NET: It can cause deadlocks

In UI apps: Freezes the UI thread

In high-throughput apps: Blocks unnecessary threads, hurting scalability

Solution: Use await
```csharp
var data = await service.GetDataAsync();
```
Fully async

Releases thread while waiting

Scales better

Prevents deadlocks