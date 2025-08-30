using Improvements.Common.Interfaces;
using System;

namespace Improvements._59_GlobalErrorHandlerVsScattered.Good
{
    public class GlobalErrorHandler : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Good: Centralized global error handling...");

            try
            {
                Step1();
            }
            catch (Exception ex)
            {
                // Global handler – log once at the top-level
                Console.WriteLine($"Global handler: {ex.Message}");
            }
        }

        private void Step1()
        {
            Step2();
        }

        private void Step2()
        {
            throw new InvalidOperationException("Something failed in Step2");
        }
    }
}
