using Improvements.Common.Interfaces;
using System;

namespace Improvements._67_ValidationLocation.Bad
{
    public class BadValidation : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("=== BAD: Validation scattered in every method ===");

            string? input = null;

            // every method repeats validation
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Error: input is required.");
                return;
            }

            Console.WriteLine($"Processing {input}");
            Console.WriteLine("Problem: Validation is repeated across methods, harder to maintain.");
            Console.WriteLine();
        }
    }
}
