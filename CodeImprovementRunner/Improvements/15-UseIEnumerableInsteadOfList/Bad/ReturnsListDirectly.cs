using Improvements.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Improvements._15_UseIEnumerableInsteadOfList.Bad
{
    public class ReturnsListDirectly : IImprovementDemo
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
            Console.WriteLine($"[Bad] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {memoryAfter - memoryBefore} bytes");
        }

        private List<string> GetNames()
        {
            return new List<string> { "Alice", "Bob", "Charlie" };
        }
    }
}
