using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._62_HardcodedUrlsVsIUrlHelper.Good
{
    public class UrlHelperUsage : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("=== GOOD: URL Helper Simulation ===");

            // Simulated helper method for URL generation
            string productUrl = GenerateUrl("Products", "Details", 5);
            string orderUrl = GenerateUrl("Orders", "Details", 10);

            Console.WriteLine($"Product URL: {productUrl}");
            Console.WriteLine($"Order URL: {orderUrl}");

            Console.WriteLine();
        }

        private string GenerateUrl(string controller, string action, int id)
        {
            // In ASP.NET Core this would use IUrlHelper, here we simulate
            return $"https://mysite.com/{controller.ToLower()}/{action.ToLower()}/{id}";
        }
    }
}
