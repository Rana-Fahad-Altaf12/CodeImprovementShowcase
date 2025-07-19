using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._30_AvoidThreadSleep.Bad
{
    public class UsingThreadSleep : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            Console.WriteLine("Starting blocking wait...");
            Thread.Sleep(2000); // blocks thread, inefficient
            Console.WriteLine("Finished blocking wait.");

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(false);
            Console.WriteLine($"[Bad] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {memoryAfter - memoryBefore} bytes");
        }
    }
}