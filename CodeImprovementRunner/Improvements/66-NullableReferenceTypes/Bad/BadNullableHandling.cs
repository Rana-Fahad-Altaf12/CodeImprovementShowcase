using Improvements.Common.Interfaces;
using System;

namespace Improvements._66_NullableReferenceTypes.Bad
{
    public class BadNullableHandling : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("=== BAD: Ignoring nullability ===");

            string? name = null; // could be null but API treats as non-null

            try
            {
                Console.WriteLine($"User: {name.ToUpper()}"); // NullReferenceException
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Runtime crash: {ex.Message}");
            }

            Console.WriteLine("Problem: API crashes if consumer passes null unexpectedly.");
            Console.WriteLine();
        }
    }
}
