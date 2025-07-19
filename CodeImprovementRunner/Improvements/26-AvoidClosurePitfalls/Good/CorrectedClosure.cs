using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._26_AvoidClosurePitfalls.Good
{
    public class CorrectedClosure : IImprovementDemo
    {
        public void Run()
            {
                var stopwatch = Stopwatch.StartNew();
                long memoryBefore = GC.GetTotalMemory(true);

                var actions = new List<Action>();

                for (int i = 0; i < 5; i++)
                {
                    int copy = i; // Capture loop variable safely
                    actions.Add(() => Console.WriteLine($"[Good] Index: {copy}"));
                }

                foreach (var action in actions)
                {
                    action();
                }

                stopwatch.Stop();
                long memoryAfter = GC.GetTotalMemory(true);

                Console.WriteLine("[Good] Time: {0}ms, Memory: {1} bytes",
                    stopwatch.ElapsedMilliseconds, memoryAfter - memoryBefore);
            }
        }
    }