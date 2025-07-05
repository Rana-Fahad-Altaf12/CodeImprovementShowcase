using System;
using System.Diagnostics;
using Improvements.Common.Interfaces;

namespace Improvements._20_AvoidEmptyCatchBlocks.Good
{
    public class CatchWithLogging : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                int x = int.Parse("invalid");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"[Handled] Format error: {ex.Message}");
            }

            stopwatch.Stop();

            Console.WriteLine($"[Good] Time: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
