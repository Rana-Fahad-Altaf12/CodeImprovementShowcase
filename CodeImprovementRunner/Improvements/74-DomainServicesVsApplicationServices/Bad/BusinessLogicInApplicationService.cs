using Improvements.Common.Interfaces;
using System;

namespace Improvements._74_DomainServicesVsApplicationServices.Bad
{
    public class BusinessLogicInApplicationService : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Bad: Putting business logic directly in application/service layer");

            var orderService = new OrderService();
            orderService.PlaceOrder(1, 5); // customerId, quantity
        }

        public class OrderService
        {
            public void PlaceOrder(int customerId, int quantity)
            {
                // Business rules in service layer (bad)
                if (quantity <= 0)
                {
                    Console.WriteLine("Cannot place order with zero or negative quantity.");
                    return;
                }

                Console.WriteLine($"Order placed for Customer {customerId} with quantity {quantity}");
            }
        }
    }
}
