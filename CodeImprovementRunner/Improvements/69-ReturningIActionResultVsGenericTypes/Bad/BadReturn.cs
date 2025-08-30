using Improvements.Common.Interfaces;
using System;

namespace Improvements._69_ReturningTypes.Bad
{
    public class BadReturn : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("=== BAD: Always returning IActionResult ===");

            Console.WriteLine("Controller method signature: IActionResult GetProduct()");
            Console.WriteLine("Return value: Ok(product)");

            Console.WriteLine("Problem:");
            Console.WriteLine("- The actual return type is hidden.");
            Console.WriteLine("- Clients can't easily know what to expect.");
            Console.WriteLine("- Makes code harder to test (needs casting).");
            Console.WriteLine();
        }
    }
}
