using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._22_AvoidLargeObjectHeap.Bad
{
    public class UsingLargeArray : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            // This array is >85,000 bytes → goes into LOH
            byte[] largeArray = new byte[100_000];

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine($"Large array length: {largeArray.Length}");
            Console.WriteLine($"[Bad] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {memoryAfter - memoryBefore} bytes");
        }
    }
}
