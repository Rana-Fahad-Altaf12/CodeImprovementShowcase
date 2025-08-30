using Improvements.Common.Interfaces;
using System;

namespace Improvements._68_Versioning.Good
{
    public class GoodVersioning : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("=== GOOD: Versioning via URL or Header ===");

            string urlVersioned = "/api/v1/products";
            string headerVersioned = "Header: api-version=1";

            Console.WriteLine($"URL style: {urlVersioned}");
            Console.WriteLine($"Header style: {headerVersioned}");

            Console.WriteLine("Benefit:");
            Console.WriteLine("- Clear and predictable API structure.");
            Console.WriteLine("- Better support for routing and caching.");
            Console.WriteLine("- Easier for clients to know which version they're using.");
            Console.WriteLine();
        }
    }
}
