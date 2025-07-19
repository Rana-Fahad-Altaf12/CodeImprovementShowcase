using Improvements.Common.Interfaces;

namespace Improvements._31_AttributeRoutingVsConventional.Bad
{
    public class ConventionalRoutingExample : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("This example uses conventional routing.");
            Console.WriteLine("Check Startup.cs for route configuration like 'controller/action/id'.");
            Console.WriteLine("Controllers are not explicitly routed.");
        }
    }

    // Simulated controller
    public class ProductsController
    {
        public string Details(int id)
        {
            return $"Product Details for {id}";
        }
    }
}