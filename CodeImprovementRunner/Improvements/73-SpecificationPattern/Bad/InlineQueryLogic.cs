using Improvements.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Improvements._73_SpecificationPattern.Bad
{
    public class InlineQueryLogic : IImprovementDemo
    {
        public void Run()
        {
            var products = new List<Product>
            {
                new() { Name = "Apple", Price = 100 },
                new() { Name = "Banana", Price = 50 },
                new() { Name = "Cherry", Price = 120 }
            };

            Console.WriteLine("Bad: Inline query logic");
            var expensiveProducts = products.Where(p => p.Price > 90).ToList();

            foreach (var p in expensiveProducts)
                Console.WriteLine($"Product: {p.Name}, Price: {p.Price}");
        }
    }

    public class Product
    {
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
    }
}
