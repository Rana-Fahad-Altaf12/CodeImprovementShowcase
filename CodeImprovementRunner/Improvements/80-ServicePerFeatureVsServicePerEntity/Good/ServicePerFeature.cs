using Improvements.Common.Interfaces;
using System;

namespace Improvements._80_ServicePerFeatureVsServicePerEntity.Good
{
    public class ServicePerFeature : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Good: Service-per-feature approach");

            var orderPlacementService = new OrderPlacementService();
            orderPlacementService.PlaceOrder(1, 101, 250.00m);
        }

        public class OrderPlacementService
        {
            public void PlaceOrder(int customerId, int productId, decimal amount)
            {
                Console.WriteLine($"Creating order for ProductId: {productId}, Amount: {amount}");
                Console.WriteLine($"Assigning order to Customer: {customerId}");
                Console.WriteLine("Sending confirmation email...");
            }
        }
    }
}
