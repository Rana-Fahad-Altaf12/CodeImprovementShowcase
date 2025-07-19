using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._23_UseSpanForSlicing.Good
{
    public class StringSlicingWithSpan : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            string input = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            ReadOnlySpan<char> inputSpan = input.AsSpan();

            for (int i = 0; i < 10000; i++)
            {
                // Span slices without allocating new memory
                ReadOnlySpan<char> slice = inputSpan.Slice(5, 10);
                char c = slice[0]; // simulate use
            }

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);
            long memorydifference = memoryAfter - memoryBefore < 0 ? 0 : memoryAfter - memoryBefore;
            Console.WriteLine("Finished slicing with Span");
            Console.WriteLine($"[Good] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {memorydifference} bytes");
        }
    }
}
