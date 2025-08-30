using Improvements.Common.Interfaces;
using System;

namespace Improvements._58_LoggingInsideCatch.Bad
{
    public class LogInsideCatch : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Bad: Logging inside catch blocks everywhere...");

            try
            {
                DoWork();
            }
            catch (Exception ex)
            {
                // Logging at every level leads to duplicate logs and noise.
                Console.WriteLine($"Error in Run: {ex.Message}");
            }
        }

        private void DoWork()
        {
            try
            {
                throw new InvalidOperationException("Something failed in DoWork");
            }
            catch (Exception ex)
            {
                // Logging here too
                Console.WriteLine($"Error in DoWork: {ex.Message}");
                throw; // still rethrowing -> double logs
            }
        }
    }
}
