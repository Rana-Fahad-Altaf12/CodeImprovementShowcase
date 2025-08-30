using Improvements.Common.Interfaces;
using System;

namespace Improvements._67_ValidationLocation.Good
{
    // Simulate a central validation filter/middleware
    public static class Validator
    {
        public static bool Validate(string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Validation failed: input is required.");
                return false;
            }
            return true;
        }
    }

    public class GoodValidation : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("=== GOOD: Centralized validation (filter/middleware) ===");

            string? input = null;

            if (!Validator.Validate(input))
                return;

            Console.WriteLine($"Processing {input}");
            Console.WriteLine("Benefit: Validation logic is reusable and consistent.");
            Console.WriteLine();
        }
    }
}
