using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._17_UseIsNullOrWhiteSpace.Good
{
    public class IsNullOrWhiteSpaceCheck : IImprovementDemo
    {
        public void Run()
        {
            string name = "   ";

            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            bool isValid = !string.IsNullOrWhiteSpace(name);

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine($"Name valid? {isValid}");
            Console.WriteLine($"[Good] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {Math.Max(0, memoryAfter - memoryBefore)} bytes");
        }
    }
}
