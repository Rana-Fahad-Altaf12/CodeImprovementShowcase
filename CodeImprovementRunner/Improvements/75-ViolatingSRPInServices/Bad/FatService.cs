using Improvements.Common.Interfaces;
using System;

namespace Improvements._75_ViolatingSRPInServices.Bad
{
    public class FatService : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Bad: Single service doing multiple responsibilities");

            var service = new FatOrderService();
            service.PlaceOrder(1, 10);
        }

        public class FatOrderService
        {
            public void PlaceOrder(int customerId, int quantity)
            {
                // Validate order
                if (quantity <= 0)
                {
                    Console.WriteLine("Invalid order quantity.");
                    return;
                }

                // Process payment
                Console.WriteLine($"Charging customer {customerId} for {quantity} items...");

                // Send confirmation email
                Console.WriteLine($"Sending confirmation email to customer {customerId}...");
            }
        }
    }
}
