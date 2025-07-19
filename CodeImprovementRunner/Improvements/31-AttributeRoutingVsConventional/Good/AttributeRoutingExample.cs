using Improvements.Common.Interfaces;
using System.Runtime.InteropServices;
using Improvements.Common.MockAttributes;

namespace Improvements._31_AttributeRoutingVsConventional.Good
{
    public class AttributeRoutingExample : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("This example uses attribute routing directly on controller/action.");
            Console.WriteLine("Controller has [Route] and [HttpGet] attributes (simulated).");
        }
    }

    // Simulated controller with fake attribute routing
    [Route("api/products")]
    public class ProductsController
    {
        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            return $"Product {id} (Attribute Routed)";
        }
    }
}