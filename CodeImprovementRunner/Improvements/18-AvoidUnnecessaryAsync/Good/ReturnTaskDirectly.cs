using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Improvements.Common.Interfaces;

namespace Improvements._18_AvoidUnnecessaryAsync.Good
{
    public class ReturnTaskDirectly : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            var result = GetValueAsync().Result;

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine($"Result: {result}");
            Console.WriteLine($"[Good] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {Math.Max(0, memoryAfter - memoryBefore)} bytes");
        }

        public Task<int> GetValueAsync()
        {
            return Task.FromResult(42);
        }
    }
}
