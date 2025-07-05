using System;
using System.Collections.Generic;
using System.Diagnostics;
using Improvements.Common.Interfaces;

namespace Improvements._19_UseVarWhenObvious.Good
{
    public class UseVarForClarity : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            var scores = new Dictionary<string, List<int>>();
            scores["math"] = new List<int> { 90, 95, 88 };

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine($"Math scores: {string.Join(", ", scores["math"])}");
            Console.WriteLine($"[Good] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {Math.Max(0, memoryAfter - memoryBefore)} bytes");
        }
    }
}
