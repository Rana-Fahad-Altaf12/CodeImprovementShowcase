using Improvements.Common.Interfaces;
using System;

namespace Improvements._53_OverusingTryCatch.Good
{
    public class MinimalTryCatch : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Starting process...");

            try
            {
                var result1 = Divide(10, 2);
                Console.WriteLine($"Division result: {result1}");

                var result2 = Divide(10, 0);
                Console.WriteLine($"Division result: {result2}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Handled divide by zero: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        private int Divide(int a, int b)
        {
            return a / b;
        }
    }
}
