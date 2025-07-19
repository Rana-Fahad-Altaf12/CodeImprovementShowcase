using Improvements.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Improvements._43_SpecificationPattern.Good
{
    public class SpecificationPatternUsage : IImprovementDemo
    {
        public void Run()
        {
            var products = GetProducts();

            var spec = new ExpensiveElectronicsSpec();
            var filtered = products.Where(p => spec.IsSatisfiedBy(p)).ToList();

            Console.WriteLine($"Found {filtered.Count} expensive electronics using specification.");
        }

        private List<Product> GetProducts() => new()
        {
            new Product("TV", 499, "Electronics"),
            new Product("Book", 20, "Stationery"),
            new Product("Headphones", 59, "Electronics"),
        };

        public interface ISpecification<T>
        {
            bool IsSatisfiedBy(T item);
        }

        public class ExpensiveElectronicsSpec : ISpecification<Product>
        {
            public bool IsSatisfiedBy(Product p) =>
                p.Price > 50 && p.Category == "Electronics";
        }

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
