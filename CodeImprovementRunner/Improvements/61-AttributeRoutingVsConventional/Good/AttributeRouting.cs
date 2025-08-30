using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._61_AttributeRoutingVsConventionalRouting.Good
{
    public class AttributeRouting : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("=== GOOD: Attribute Routing Simulation ===");

            // Pretend attributes define routes explicitly
            var route = "/products/5";
            var resolved = ResolveByAttribute(route);

            Console.WriteLine($"Route: {route}");
            Console.WriteLine($"Resolved To: {resolved}");

            Console.WriteLine();
        }

        private string ResolveByAttribute(string route)
        {
            if (route == "/products/5") return "ProductsController -> GetById(5)";
            if (route == "/orders/7") return "OrdersController -> GetById(7)";
            return "Unknown";
        }
    }
}
