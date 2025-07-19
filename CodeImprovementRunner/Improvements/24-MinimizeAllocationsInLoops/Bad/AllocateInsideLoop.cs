using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._24_MinimizeAllocationsInLoops.Bad
{
    public class AllocateInsideLoop : IImprovementDemo
    {
        private class SampleObject
        {
            public int Value { get; set; }
        }
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            int total = 0;
            for (int i = 0; i < 100000; i++)
            {
                // Allocates new object every iteration
                var obj = new SampleObject { Value = i };
                total += obj.Value;
            }

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine("Finished allocating in loop");
            Console.WriteLine("[Bad] Time: {0}ms, Memory: {1} bytes", stopwatch.ElapsedMilliseconds, memoryAfter - memoryBefore);
        }
    }
}
