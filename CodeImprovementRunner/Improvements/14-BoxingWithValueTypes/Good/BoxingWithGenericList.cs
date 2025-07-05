using Improvements.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Improvements._14_BoxingWithValueTypes.Good
{
    public class BoxingWithGenericList : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            List<int> numbers = new List<int>();
            for (int i = 0; i < 100000; i++)
            {
                numbers.Add(i); // No boxing
            }

            long sum = 0;
            foreach (int item in numbers)
            {
                sum += item; // No unboxing
            }

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine($"Total Sum: {sum}");
            Console.WriteLine($"[Good] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {memoryAfter - memoryBefore} bytes");
        }
    }
}
