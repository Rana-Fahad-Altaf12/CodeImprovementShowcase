using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._28_AvoidExcessiveLogging.Bad
{
    public class TooMuchLogging : IImprovementDemo
    {
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
            Console.WriteLine($"[Bad] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {memoryAfter - memoryBefore} bytes");
        }

        private void LogDebug(string message)
        {
            // Simulates debug logging
            Console.WriteLine(message);
        }
    }
}