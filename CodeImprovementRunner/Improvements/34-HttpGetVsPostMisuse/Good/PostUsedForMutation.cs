using Improvements.Common.Interfaces;
using Improvements.Common.MockAttributes;
namespace Improvements._34_HttpGetVsPostMisuse.Good
{
    public class PostUsedForMutation : IImprovementDemo
    {
        [Route("api/orders")]
        public class OrderController
        {
            [HttpPost("create")]
            public string CreateOrder([FromBody] int productId)
            {
                return $"Order created for product {productId} (using POST)";
            }
        }

        public void Run()
        {
            var controller = new OrderController();
            Console.WriteLine(controller.CreateOrder(123));
        }
    }
}
