using Improvements.Common.Interfaces;
using Improvements.Common.MockAttributes;
namespace Improvements._34_HttpGetVsPostMisuse.Bad
{
    public class GetUsedForMutation : IImprovementDemo
    {
        [Route("api/orders")]
        public class OrderController
        {
            [HttpGet("create")]
            public string CreateOrder([FromQuery] int productId)
            {
                return $"Order created for product {productId} (improperly using GET)";
            }
        }

        public void Run()
        {
            var controller = new OrderController();
            Console.WriteLine(controller.CreateOrder(123));
        }
    }
}
