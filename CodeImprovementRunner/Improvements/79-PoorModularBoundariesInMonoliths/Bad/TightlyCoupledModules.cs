using Improvements.Common.Interfaces;
using System;

namespace Improvements._79_PoorModularBoundariesInMonoliths.Bad
{
    public class TightlyCoupledModules : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Bad: Monolith with tightly coupled modules");

            var orderService = new OrderService();
            var paymentService = new PaymentService(orderService);

            paymentService.ProcessPayment(101, 250.00m);
        }

        public class OrderService
        {
            public void CreateOrder(int orderId, decimal amount)
            {
                Console.WriteLine($"Order {orderId} created for amount {amount}");
            }
        }

        public class PaymentService
        {
            private readonly OrderService _orderService;

            public PaymentService(OrderService orderService)
            {
                _orderService = orderService;
            }

            public void ProcessPayment(int orderId, decimal amount)
            {
                Console.WriteLine($"Processing payment for order {orderId}");
                _orderService.CreateOrder(orderId, amount); // Direct dependency
            }
        }
    }
}
