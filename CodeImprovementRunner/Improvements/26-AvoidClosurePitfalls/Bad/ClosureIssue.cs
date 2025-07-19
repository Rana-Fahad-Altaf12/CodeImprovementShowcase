using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._26_AvoidClosurePitfalls.Bad
{
    public class ClosureIssue : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            var actions = new List<Action>();

            for (int i = 0; i < 5; i++)
            {
                // All closures capture the same variable 'i'
                actions.Add(() => Console.WriteLine($"[Bad] Index: {i}"));
            }

            foreach (var action in actions)
            {
                action();
            }

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine("[Bad] Time: {0}ms, Memory: {1} bytes",
                stopwatch.ElapsedMilliseconds, memoryAfter - memoryBefore);
        }
    }
}