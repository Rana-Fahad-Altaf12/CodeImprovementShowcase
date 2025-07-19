using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._21_AvoidUnnecessaryBoxing.Good
{
    public class DirectIntegerUsage : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            int value = 42;
            int direct = value;

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine($"Direct value: {direct}");
            Console.WriteLine($"[Good] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {memoryAfter - memoryBefore} bytes");
        }
    }
}
