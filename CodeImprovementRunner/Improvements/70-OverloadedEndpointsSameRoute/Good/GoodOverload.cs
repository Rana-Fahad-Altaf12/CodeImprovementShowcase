using Improvements.Common.Interfaces;
using System;

namespace Improvements._70_OverloadedRoutes.Good
{
    public class GoodOverload : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("=== GOOD: Unique, unambiguous routes ===");

            Console.WriteLine("Example:");
            Console.WriteLine("[HttpGet(\"products/by-id/{id:int}\")] public IActionResult GetById(int id)");
            Console.WriteLine("[HttpGet(\"products/by-name/{name}\")] public IActionResult GetByName(string name)");

            Console.WriteLine("Benefit:");
            Console.WriteLine("- No ambiguity in routing.");
            Console.WriteLine("- Clear intent for both developers and clients.");
            Console.WriteLine("- Easier API documentation and client generation.");
            Console.WriteLine();
        }
    }
}
