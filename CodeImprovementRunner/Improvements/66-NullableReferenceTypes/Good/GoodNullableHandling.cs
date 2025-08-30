using Improvements.Common.Interfaces;
using System;

namespace Improvements._66_NullableReferenceTypes.Good
{
    public class GoodNullableHandling : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("=== GOOD: Using nullable reference types ===");

#nullable enable
            string? name = null;

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("User name not provided.");
            }
            else
            {
                Console.WriteLine($"User: {name.ToUpper()}");
            }
#nullable restore

            Console.WriteLine("Benefit: Compiler enforces null checks, fewer runtime crashes.");
            Console.WriteLine();
        }
    }
}
