using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._21_AvoidUnnecessaryBoxing.Bad
{
    public class BoxedInteger : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            object boxedValue;
            int value = 42;
            boxedValue = value; // boxing
            int unboxed = (int)boxedValue; // unboxing

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine($"Unboxed value: {unboxed}");
            Console.WriteLine($"[Bad] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {memoryAfter - memoryBefore} bytes");
        }
    }
}
