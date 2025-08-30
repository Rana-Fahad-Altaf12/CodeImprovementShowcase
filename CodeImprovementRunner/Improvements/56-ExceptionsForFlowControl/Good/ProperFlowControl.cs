using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._56_ExceptionsForFlowControl.Good
{
    public class ProperFlowControl : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            int[] numbers = { 1, 2, 3, 4, 5 };
            int found = -1;

            foreach (var num in numbers)
            {
                if (num == 4)
                {
                    found = 4; // GOOD: normal condition check
                    break;
                }
            }

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(false);

            Console.WriteLine($"Good Result = {found}");
            Console.WriteLine($"Time: {stopwatch.ElapsedTicks} ticks");
            Console.WriteLine($"Memory: {memoryAfter - memoryBefore} bytes");
        }
    }
}
