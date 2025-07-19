using Improvements.Common.Interfaces;
using System;

namespace Improvements._50_ServicePerFeatureVsEntity.Bad
{
    public class ServicePerEntityApproach : IImprovementDemo
    {
        public void Run()
        {
            var orderService = new OrderService();
            var customerService = new CustomerService();

            var order = orderService.CreateOrder(123, 250.00m);
            customerService.AssignOrderToCustomer(1, order);

            Console.WriteLine("Process completed (entity-based services).");
        }

        public class OrderService
        {
            public Order CreateOrder(int productId, decimal amount)
            {
                Console.WriteLine($"Creating order for ProductId: {productId}, Amount: {amount}");
                return new Order { ProductId = productId, Amount = amount };
            }
        }

        public class CustomerService
        {
            public void AssignOrderToCustomer(int customerId, Order order)
            {
                Console.WriteLine($"Assigning Order for Product {order.ProductId} to Customer {customerId}");
            }
        }

        public class Order
        {
            public int ProductId { get; set; }
            public decimal Amount { get; set; }
        }
    }
}
