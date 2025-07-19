using Improvements.Common.Interfaces;
namespace Improvements._36_NullableReferenceTypesInApi.Good
{
    public class NullableTypesUsedProperly : IImprovementDemo
    {
        public class Product
        {
            public string Name { get; set; }
            public string? Description { get; set; } // Nullable is explicit
        }

        public class ProductController
        {
            public Product GetProduct()
            {
                return new Product
                {
                    Name = "Laptop",
                    Description = null
                };
            }
        }

        public void Run()
        {
            var controller = new ProductController();
            var product = controller.GetProduct();

            Console.WriteLine($"Product Name Length: {product.Name.Length}");
            Console.WriteLine($"Description: {product.Description ?? "No description available"}");
        }
    }
}
