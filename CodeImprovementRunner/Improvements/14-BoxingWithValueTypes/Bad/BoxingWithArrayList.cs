using Improvements.Common.Interfaces;
using System;
using System.Collections;
using System.Diagnostics;

namespace Improvements._14_BoxingWithValueTypes.Bad
{
    public class BoxingWithArrayList : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            ArrayList numbers = new ArrayList();
            for (int i = 0; i < 100000; i++)
            {
                numbers.Add(i); // Boxing
            }

            long sum = 0;
            foreach (object item in numbers)
            {
                sum += (int)item; // Unboxing
            }

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine($"Total Sum: {sum}");
            Console.WriteLine($"[Bad] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {memoryAfter - memoryBefore} bytes");
        }
    }
}
