using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._30_AvoidThreadSleep.Good
{
    public class UseTaskDelay : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            Console.WriteLine("Starting non-blocking wait...");
            Task.Delay(2000).GetAwaiter().GetResult(); // non-blocking pattern
            Console.WriteLine("Finished non-blocking wait.");

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(false);
            Console.WriteLine($"[Good] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {memoryAfter - memoryBefore} bytes");
        }
    }
}