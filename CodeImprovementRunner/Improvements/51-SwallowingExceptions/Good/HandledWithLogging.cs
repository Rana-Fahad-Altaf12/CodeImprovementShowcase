using Improvements.Common.Interfaces;
using System;

namespace Improvements._51_SwallowingExceptions.Good
{
    public class HandledWithLogging : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Starting process (Good)...");

            try
            {
                DangerousOperation();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                // Rethrow to preserve stack trace
                throw;
            }
        }

        private void DangerousOperation()
        {
            throw new InvalidOperationException("Something went wrong in DangerousOperation!");
        }
    }
}
