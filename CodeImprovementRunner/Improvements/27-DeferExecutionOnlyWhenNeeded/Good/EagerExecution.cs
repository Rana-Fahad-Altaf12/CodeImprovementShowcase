using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._27_DeferExecutionOnlyWhenNeeded.Good
{
    public class EagerExecution : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            var numbers = Enumerable.Range(1, 1000000);
            var evens = numbers.Where(n => n % 2 == 0).ToList(); // Execute once

            Console.WriteLine("[Good] Count of even numbers: " + evens.Count);
            Console.WriteLine("[Good] Max of even numbers: " + evens.Max());

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);
            Console.WriteLine("[Good] Time: {0}ms, Memory: {1} bytes",
                stopwatch.ElapsedMilliseconds, memoryAfter - memoryBefore);
        }
    }
}