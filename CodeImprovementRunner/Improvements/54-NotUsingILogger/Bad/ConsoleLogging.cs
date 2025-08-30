using Improvements.Common.Interfaces;
using System;

namespace Improvements._54_NotUsingILogger.Bad
{
    public class ConsoleLogging : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Starting application...");

            try
            {
                var result = Divide(10, 0);
                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                // Logging sensitive and unstructured
                Console.WriteLine($"Exception: {ex}");
            }

            Console.WriteLine("Application finished.");
        }

        private int Divide(int a, int b) => a / b;
    }
}
