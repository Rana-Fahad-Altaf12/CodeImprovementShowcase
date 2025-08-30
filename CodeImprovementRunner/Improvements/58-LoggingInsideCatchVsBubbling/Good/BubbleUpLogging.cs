using Improvements.Common.Interfaces;
using System;

namespace Improvements._58_LoggingInsideCatch.Good
{
    public class BubbleUpLogging : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Good: Bubbling up exceptions and logging once...");

            try
            {
                DoWork();
            }
            catch (Exception ex)
            {
                // Log once at the boundary (e.g., service or controller layer).
                Console.WriteLine($"Handled in Run: {ex.Message}");
            }
        }

        private void DoWork()
        {
            // No logging here, just throw
            throw new InvalidOperationException("Something failed in DoWork");
        }
    }
}
