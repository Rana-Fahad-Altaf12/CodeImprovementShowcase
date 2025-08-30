using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._62_HardcodedUrlsVsIUrlHelper.Bad
{
    public class HardcodedUrls : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("=== BAD: Hardcoded URLs Simulation ===");

            // Hardcoding links (fragile if routes change)
            string productUrl = "https://mysite.com/products/details/5";
            string orderUrl = "https://mysite.com/orders/details/10";

            Console.WriteLine($"Product URL: {productUrl}");
            Console.WriteLine($"Order URL: {orderUrl}");

            Console.WriteLine();
        }
    }
}
