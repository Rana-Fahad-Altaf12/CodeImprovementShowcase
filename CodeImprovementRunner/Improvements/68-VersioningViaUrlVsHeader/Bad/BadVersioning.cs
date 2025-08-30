using Improvements.Common.Interfaces;
using System;

namespace Improvements._68_Versioning.Bad
{
    public class BadVersioning : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("=== BAD: Versioning via query string ===");

            string url = "/api/products?version=1";
            Console.WriteLine($"Request: {url}");

            Console.WriteLine("Problem:");
            Console.WriteLine("- Query params are easy to forget/change.");
            Console.WriteLine("- Harder to cache at CDN/proxy level.");
            Console.WriteLine("- Not the recommended REST practice.");
            Console.WriteLine();
        }
    }
}
