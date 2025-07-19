using Improvements.Common.Interfaces;
using System;

namespace Improvements._44_DomainVsApplicationServices.Bad
{
    public class BusinessLogicInApplicationService : IImprovementDemo
    {
        public void Run()
        {
            var order = new Order(500, false);
            var appService = new OrderApplicationService();
            var result = appService.CanApplyDiscount(order);

            Console.WriteLine($"Discount allowed: {result}");
        }

        public class Order
        {
            public decimal Amount { get; }
            public bool IsDiscounted { get; }

            public Order(decimal amount, bool isDiscounted)
            {
                Amount = amount;
                IsDiscounted = isDiscounted;
            }
        }

        public class OrderApplicationService
        {
            public bool CanApplyDiscount(Order order)
            {
                // Business logic directly in application service
                return order.Amount > 300 && !order.IsDiscounted;
            }
        }
    }
}
