using Improvements.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Improvements._43_SpecificationPattern.Bad
{
    public class HardcodedFilterLogic : IImprovementDemo
    {
        public void Run()
        {
            var products = GetProducts();

            var filtered = products
                .Where(p => p.Price > 50 && p.Category == "Electronics")
                .ToList();

            Console.WriteLine($"Found {filtered.Count} expensive electronics.");
        }

        private List<Product> GetProducts() => new()
        {
            new Product("TV", 499, "Electronics"),
            new Product("Book", 20, "Stationery"),
            new Product("Headphones", 59, "Electronics"),
        };

        public class Product
        {
            public string Name { get; }
            public decimal Price { get; }
            public string Category { get; }

            public Product(string name, decimal price, string category)
            {
                Name = name;
                Price = price;
                Category = category;
            }
        }
    }
}
