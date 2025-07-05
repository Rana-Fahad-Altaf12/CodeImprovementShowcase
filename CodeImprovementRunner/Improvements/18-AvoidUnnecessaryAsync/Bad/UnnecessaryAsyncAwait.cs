using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Improvements.Common.Interfaces;

namespace Improvements._18_AvoidUnnecessaryAsync.Bad
{
    public class UnnecessaryAsyncAwait : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            var result = GetValueAsync().Result;

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine($"Result: {result}");
            Console.WriteLine($"[Bad] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {memoryAfter - memoryBefore} bytes");
        }

        public async Task<int> GetValueAsync()
        {
            return await Task.FromResult(42);
        }
    }
}
