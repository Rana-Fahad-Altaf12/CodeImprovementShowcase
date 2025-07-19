using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._27_DeferExecutionOnlyWhenNeeded.Bad
{
    public class UnexpectedDeferredExecution : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            var numbers = Enumerable.Range(1, 1000000);
            var evens = numbers.Where(n => n % 2 == 0);

            // LINQ not yet executed (deferred)
            Console.WriteLine("[Bad] Count of even numbers: " + evens.Count());

            // Re-evaluates whole query again
            Console.WriteLine("[Bad] Max of even numbers: " + evens.Max());

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);
            Console.WriteLine("[Bad] Time: {0}ms, Memory: {1} bytes",
                stopwatch.ElapsedMilliseconds, memoryAfter - memoryBefore);
        }
    }
}