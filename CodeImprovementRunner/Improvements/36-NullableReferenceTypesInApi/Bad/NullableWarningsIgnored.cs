using Improvements.Common.Interfaces;
namespace Improvements._36_NullableReferenceTypesInApi.Bad
{
    public class NullableWarningsIgnored : IImprovementDemo
    {
        public class Product
        {
            public string Name { get; set; } // Nullable at runtime, but not declared as such
            public string Description { get; set; }
        }

        public class ProductController
        {
            public Product GetProduct()
            {
                return new Product
                {
                    Name = null, // No compiler warning
                    Description = "No description"
                };
            }
        }

        public void Run()
        {
            var controller = new ProductController();
            var product = controller.GetProduct();

            Console.WriteLine($"Product Name Length: {product.Name.Length}"); // May throw!
        }
    }
}
