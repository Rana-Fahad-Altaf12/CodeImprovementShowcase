using Improvements.Common.Interfaces;
using System;

namespace Improvements._50_ServicePerFeatureVsEntity.Good
{
    public class ServicePerFeatureApproach : IImprovementDemo
    {
        public void Run()
        {
            var orderPlacementService = new OrderPlacementService();
            orderPlacementService.PlaceOrder(1, 123, 250.00m);

            Console.WriteLine("Process completed (feature-based service).");
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
