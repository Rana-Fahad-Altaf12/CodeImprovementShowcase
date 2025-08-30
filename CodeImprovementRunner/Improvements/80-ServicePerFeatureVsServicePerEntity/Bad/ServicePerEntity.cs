using Improvements.Common.Interfaces;
using System;

namespace Improvements._80_ServicePerFeatureVsServicePerEntity.Bad
{
    public class ServicePerEntity : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Bad: Service-per-entity approach");

            var orderService = new OrderService();
            var customerService = new CustomerService();

            var order = orderService.CreateOrder(101, 250.00m);
            customerService.AssignOrderToCustomer(1, order);
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
