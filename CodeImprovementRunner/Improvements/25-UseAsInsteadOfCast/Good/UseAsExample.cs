using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._25_UseAsInsteadOfCast.Good
{
    public class UseAsExample : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            object[] items = new object[] { "hello", 123, "world", new object(), null };
            int success = 0;

            foreach (var item in items)
            {
                // Safe cast, returns null instead of throwing
                string str = item as string;
                if (str != null)
                {
                    success += str.Length;
                }
            }

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine("Finished casting using 'as'");
            Console.WriteLine("[Good] Time: {0}ms, Memory: {1} bytes", stopwatch.ElapsedMilliseconds, memoryAfter - memoryBefore);
        }
    }
}