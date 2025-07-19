using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._29_UseCancellationTokens.Good
{
    public class UsesCancellationToken : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            var cts = new CancellationTokenSource();
            var task = LongRunningOperation(cts.Token);

            cts.CancelAfter(100); // Cancel after 100ms

            try
            {
                task.Wait();
            }
            catch (AggregateException ex) when (ex.InnerException is TaskCanceledException)
            {
                Console.WriteLine("Task was canceled.");
            }

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(false);
            Console.WriteLine($"[Good] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {memoryAfter - memoryBefore} bytes");
        }

        private async Task LongRunningOperation(CancellationToken token)
        {
            await Task.Delay(3000, token); // Cooperative cancellation
        }
    }
}