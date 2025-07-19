using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._29_UseCancellationTokens.Bad
{
    public class MissingCancellation : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            var task = LongRunningOperation(); // no cancellation support
            Thread.Sleep(100); // simulate wanting to cancel
            // No way to cancel here, even if it's unnecessary

            task.Wait();

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(false);
            Console.WriteLine($"[Bad] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {memoryAfter - memoryBefore} bytes");
        }

        private async Task LongRunningOperation()
        {
            await Task.Delay(3000); // Simulate long work
        }
    }
}