using Improvements.Common.Interfaces;
using System;

namespace Improvements._64_HttpGetVsPost.Bad
{
    public class BadHttpGetForUpdate : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("=== BAD: Using GET for updates ===");

            string url = "https://mysite.com/updateUser?id=42&name=John";
            Console.WriteLine($"Calling URL: {url}");
            Console.WriteLine("Problem: GET should not change server state. This breaks idempotency and caching.");
            Console.WriteLine();
        }
    }
}
