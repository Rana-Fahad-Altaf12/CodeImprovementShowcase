using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._56_ExceptionsForFlowControl.Bad
{
    public class ExceptionsAsFlowControl : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            int[] numbers = { 1, 2, 3, 4, 5 };
            int found = -1;

            try
            {
                foreach (var num in numbers)
                {
                    if (num == 4)
                        throw new Exception("Found the number!");
                }
            }
            catch (Exception)
            {
                found = 4; // BAD: using exception as a 'signal'
            }

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(false);

            Console.WriteLine($"Bad Result = {found}");
            Console.WriteLine($"Time: {stopwatch.ElapsedTicks} ticks");
            Console.WriteLine($"Memory: {memoryAfter - memoryBefore} bytes");
        }
    }
}
