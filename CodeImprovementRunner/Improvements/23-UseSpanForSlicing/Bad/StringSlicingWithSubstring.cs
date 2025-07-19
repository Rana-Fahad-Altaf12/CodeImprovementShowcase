using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._23_UseSpanForSlicing.Bad
{
    public class StringSlicingWithSubstring : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            string input = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < 10000; i++)
            {
                // Substring allocates a new string on each call
                string sub = input.Substring(5, 10);
            }

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine("Finished slicing with Substring");
            Console.WriteLine($"[Bad] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {memoryAfter - memoryBefore} bytes");
        }
    }
}
