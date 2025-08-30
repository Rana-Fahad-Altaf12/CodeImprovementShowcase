using Improvements.Common.Interfaces;
using System;

namespace Improvements._76_FatControllersVsThinControllers.Bad
{
    public class FatController : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Bad: Fat controller doing too much");

            var controller = new OrderController();
            controller.CreateOrder(1, 5);
        }

        public class OrderController
        {
            public void CreateOrder(int customerId, int quantity)
            {
                // Validate input
                if (quantity <= 0)
                {
                    Console.WriteLine("Invalid quantity.");
                    return;
                }

                // Process order
                Console.WriteLine($"Processing order for customer {customerId}, quantity {quantity}...");

                // Update database (simulated)
                Console.WriteLine("Saving order to database...");

                // Send email
                Console.WriteLine("Sending confirmation email...");

                // Log
                Console.WriteLine("Logging order creation...");
            }
        }
    }
}
