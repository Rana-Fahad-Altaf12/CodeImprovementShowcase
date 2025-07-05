using System;
using System.Collections.Generic;
using System.Diagnostics;
using Improvements.Common.Interfaces;

namespace Improvements._19_UseVarWhenObvious.Bad
{
    public class ExplicitTypeWhenObvious : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            Dictionary<string, List<int>> scores = new Dictionary<string, List<int>>();
            scores["math"] = new List<int> { 90, 95, 88 };

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine($"Math scores: {string.Join(", ", scores["math"])}");
            Console.WriteLine($"[Bad] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {memoryAfter - memoryBefore} bytes");
        }
    }
}
