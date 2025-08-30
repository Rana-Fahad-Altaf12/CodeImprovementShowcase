using Improvements.Common.Interfaces;
using System;

namespace Improvements._64_HttpGetVsPost.Good
{
    public class GoodHttpPostForUpdate : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("=== GOOD: Using POST for updates ===");

            string url = "https://mysite.com/users/42/update";
            string body = "{ \"name\": \"John\" }";

            Console.WriteLine($"POST {url}");
            Console.WriteLine($"Body: {body}");
            Console.WriteLine("Benefit: Properly uses POST for modifications, aligns with REST principles.");
            Console.WriteLine();
        }
    }
}
