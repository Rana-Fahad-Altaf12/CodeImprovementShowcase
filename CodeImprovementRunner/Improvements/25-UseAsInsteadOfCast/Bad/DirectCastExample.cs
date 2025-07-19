using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._25_UseAsInsteadOfCast.Bad
{
    public class DirectCastExample : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            object[] items = new object[] { "hello", 123, "world", new object(), null };
            int success = 0;

            foreach (var item in items)
            {
                try
                {
                    // May throw InvalidCastException
                    string str = (string)item;
                    success += str.Length;
                }
                catch (InvalidCastException)
                {
                    // Exception swallowed for demo
                }
            }

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine("Finished casting using (T)");
            Console.WriteLine("[Bad] Time: {0}ms, Memory: {1} bytes", stopwatch.ElapsedMilliseconds, memoryAfter - memoryBefore);
        }
    }
}
