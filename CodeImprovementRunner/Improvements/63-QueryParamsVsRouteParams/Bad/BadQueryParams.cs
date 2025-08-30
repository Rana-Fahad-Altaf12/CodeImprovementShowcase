using Improvements.Common.Interfaces;
using System;

namespace Improvements._63_QueryVsRouteParams.Bad
{
    public class BadQueryParams : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("=== BAD: Query Parameters for IDs ===");

            // Simulating endpoint call with query param for resource
            string url = "https://mysite.com/products/details?id=42";

            Console.WriteLine($"Fetching product with URL: {url}");
            Console.WriteLine("Problem: IDs in query params reduce readability and RESTfulness.");
            Console.WriteLine();
        }
    }
}
