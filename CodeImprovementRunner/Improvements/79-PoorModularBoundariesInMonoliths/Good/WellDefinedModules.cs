using Improvements.Common.Interfaces;
using System;

namespace Improvements._79_PoorModularBoundariesInMonoliths.Good
{
    public class WellDefinedModules : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Good: Monolith with well-defined, decoupled modules");

            var orderService = new OrderService();
            var paymentService = new PaymentService();

            var order = orderService.CreateOrder(101, 250.00m);
            paymentService.ProcessPayment(order);
        }

        public class OrderService
        {
            public Order CreateOrder(int orderId, decimal amount)
            {
                Console.WriteLine($"Order {orderId} created for amount {amount}");
                return new Order { Id = orderId, Amount = amount };
            }
        }

        public class PaymentService
        {
            public void ProcessPayment(Order order)
            {
                Console.WriteLine($"Processing payment for order {order.Id} with amount {order.Amount}");
            }
        }

        public class Order
        {
            public int Id { get; set; }
            public decimal Amount { get; set; }
        }
    }
}
