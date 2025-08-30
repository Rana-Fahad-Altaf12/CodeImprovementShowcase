using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._61_AttributeRoutingVsConventionalRouting.Bad
{
    public class ConventionalRouting : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("=== BAD: Conventional Routing Simulation ===");

            // Pretend routes are hardcoded in a routing table
            string route = "/products/details/5";
            string controller = GetController(route);
            string action = GetAction(route);

            Console.WriteLine($"Route: {route}");
            Console.WriteLine($"Resolved Controller: {controller}, Action: {action}");

            Console.WriteLine();
        }

        private string GetController(string route)
        {
            if (route.StartsWith("/products")) return "ProductsController";
            if (route.StartsWith("/orders")) return "OrdersController";
            return "Unknown";
        }

        private string GetAction(string route)
        {
            if (route.Contains("details")) return "Details";
            if (route.Contains("list")) return "List";
            return "Unknown";
        }
    }
}
