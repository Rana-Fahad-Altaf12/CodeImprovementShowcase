using Improvements.Common.Interfaces;
using System;

namespace Improvements._63_QueryVsRouteParams.Good
{
    public class GoodRouteParams : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("=== GOOD: Route Parameters for IDs ===");

            // Simulating endpoint call with route param
            string url = "https://mysite.com/products/42";

            Console.WriteLine($"Fetching product with URL: {url}");
            Console.WriteLine("Benefit: Clean, RESTful, resource-oriented design.");
            Console.WriteLine();
        }
    }
}
