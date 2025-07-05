using Improvements.Common.Interfaces;
using Improvements.Common.Models;
using System.Diagnostics;

namespace Improvements._13_ToListBeforeAny.Good
{
    public class DirectAnyCheckExample : IImprovementDemo
    {
        public void Run()
        {
            var users = GenerateUsers();

            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            bool anyActive = users.Any(u => u.IsActive);

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine($"Any active users? {anyActive}");
            Console.WriteLine($"[Good] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {memoryAfter - memoryBefore} bytes");
        }

        private List<User> GenerateUsers()
        {
            return Enumerable.Range(1, 100_000).Select(i => new User
            {
                Id = i,
                Name = "User" + i,
                IsActive = i % 5 == 0
            }).ToList();
        }
    }
}
