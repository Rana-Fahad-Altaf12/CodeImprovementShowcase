using Improvements.Common.Interfaces;
using System;

namespace Improvements._59_GlobalErrorHandlerVsScattered.Bad
{
    public class ScatteredTryCatch : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Bad: Scattered try-catch everywhere...");

            try
            {
                Step1();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Run: {ex.Message}");
            }
        }

        private void Step1()
        {
            try
            {
                Step2();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Step1: {ex.Message}");
            }
        }

        private void Step2()
        {
            try
            {
                throw new InvalidOperationException("Something failed in Step2");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Step2: {ex.Message}");
            }
        }
    }
}
