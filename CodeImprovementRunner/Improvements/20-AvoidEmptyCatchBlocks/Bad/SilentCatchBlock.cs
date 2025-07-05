using System;
using System.Diagnostics;
using Improvements.Common.Interfaces;

namespace Improvements._20_AvoidEmptyCatchBlocks.Bad
{
    public class SilentCatchBlock : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                int x = int.Parse("invalid");
            }
            catch
            {
                // silently swallowed — BAD!
            }

            stopwatch.Stop();

            Console.WriteLine("[Bad] Completed silently");
            Console.WriteLine($"[Bad] Time: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
