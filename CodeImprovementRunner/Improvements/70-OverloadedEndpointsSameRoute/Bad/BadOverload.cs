using Improvements.Common.Interfaces;
using System;

namespace Improvements._70_OverloadedRoutes.Bad
{
    public class BadOverload : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("=== BAD: Overloaded endpoints with same route ===");

            Console.WriteLine("Example:");
            Console.WriteLine("[HttpGet(\"products/{id}\")] public IActionResult Get(int id)");
            Console.WriteLine("[HttpGet(\"products/{name}\")] public IActionResult Get(string name)");

            Console.WriteLine("Problem:");
            Console.WriteLine("- Route ambiguity at runtime.");
            Console.WriteLine("- Framework may not know which action to pick.");
            Console.WriteLine("- Leads to unexpected 404 or runtime errors.");
            Console.WriteLine();
        }
    }
}
