using Improvements.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Improvements._15_UseIEnumerableInsteadOfList.Good
{
    public class ReturnsIEnumerable : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            var names = GetNames();
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);
            Console.WriteLine($"[Good] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {Math.Max(0, memoryAfter - memoryBefore)} bytes");
        }

        private IEnumerable<string> GetNames()
        {
            yield return "Alice";
            yield return "Bob";
            yield return "Charlie";
        }
    }
}
