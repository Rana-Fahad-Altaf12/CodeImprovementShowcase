using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._28_AvoidExcessiveLogging.Good
{
    public class EssentialLoggingOnly : IImprovementDemo
    {
        private readonly bool isDebugEnabled = false;

        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            for (int i = 0; i < 100_000; i++)
            {
                LogDebug("Processing item " + i);
            }

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(false);
            Console.WriteLine($"[Good] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {memoryAfter - memoryBefore} bytes");
        }

        private void LogDebug(string message)
        {
            if (isDebugEnabled)
            {
                Console.WriteLine(message);
            }
        }
    }
}