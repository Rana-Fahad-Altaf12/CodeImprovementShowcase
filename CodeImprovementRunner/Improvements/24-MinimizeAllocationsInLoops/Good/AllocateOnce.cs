using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._24_MinimizeAllocationsInLoops.Good
{
    public class AllocateOnce : IImprovementDemo
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
            var obj = new SampleObject(); // Reuse single object

            for (int i = 0; i < 100000; i++)
            {
                obj.Value = i;
                total += obj.Value;
            }

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine("Finished reusing object in loop");
            Console.WriteLine("[Good] Time: {0}ms, Memory: {1} bytes", stopwatch.ElapsedMilliseconds, memoryAfter - memoryBefore);
        }
    }
}
