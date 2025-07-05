using Improvements.Common.Interfaces;
using Improvements.Common.Models;
using System.Diagnostics;

namespace Improvements._12_WhereVsFirstOrDefaultPredicate.Bad
{
    public class WhereThenFirstOrDefaultExample : IImprovementDemo
    {
        public void Run()
        {
            var users = GenerateUsers();

            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            var user = users.Where(u => u.Id == 42).FirstOrDefault();

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine($"User Found: {user?.Name}");
            Console.WriteLine($"[Bad] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {memoryAfter - memoryBefore} bytes");
        }

        private List<User> GenerateUsers()
        {
            return Enumerable.Range(1, 100_000).Select(i => new User
            {
                Id = i,
                Name = "User" + i,
                IsActive = true
            }).ToList();
        }
    }
}
