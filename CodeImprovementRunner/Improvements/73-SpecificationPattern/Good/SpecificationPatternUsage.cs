using Improvements.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Improvements._73_SpecificationPattern.Good
{
    public class SpecificationPatternUsage : IImprovementDemo
    {
        public void Run()
        {
            var products = new List<Product>
            {
                new() { Name = "Apple", Price = 100 },
                new() { Name = "Banana", Price = 50 },
                new() { Name = "Cherry", Price = 120 }
            };

            Console.WriteLine("Good: Using Specification Pattern");
            var spec = new ExpensiveProductSpecification(90);
            var filtered = products.Where(p => spec.IsSatisfiedBy(p)).ToList();

            foreach (var p in filtered)
                Console.WriteLine($"Product: {p.Name}, Price: {p.Price}");
        }
    }

    public class Product
    {
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
    }

    public class ExpensiveProductSpecification
    {
        private readonly decimal _minPrice;
        public ExpensiveProductSpecification(decimal minPrice) => _minPrice = minPrice;

        public bool IsSatisfiedBy(Product p) => p.Price > _minPrice;
    }
}
