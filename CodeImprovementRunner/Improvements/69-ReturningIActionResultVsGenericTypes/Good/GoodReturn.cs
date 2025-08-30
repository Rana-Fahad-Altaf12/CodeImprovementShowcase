using Improvements.Common.Interfaces;
using System;

namespace Improvements._69_ReturningTypes.Good
{
    public class GoodReturn : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("=== GOOD: Returning generic ActionResult<T> ===");

            Console.WriteLine("Controller method signature: ActionResult<ProductDto> GetProduct()");
            Console.WriteLine("Return value: ProductDto directly, wrapped by framework if needed");

            Console.WriteLine("Benefit:");
            Console.WriteLine("- Clients know exactly what type is returned.");
            Console.WriteLine("- Still supports HTTP results (e.g., NotFound, BadRequest).");
            Console.WriteLine("- Easier to test and more type-safe.");
            Console.WriteLine();
        }
    }
}
