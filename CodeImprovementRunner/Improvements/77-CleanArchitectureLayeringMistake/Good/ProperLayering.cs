using Improvements.Common.Interfaces;
using System;

namespace Improvements._77_CleanArchitectureLayeringMistake.Good
{
    public class ProperLayering : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Good: UI layer interacts via application/service layer");

            var service = new OrderService();
            var ui = new UiLayer(service);

            ui.ShowOrders();
        }

        public class UiLayer
        {
            private readonly OrderService _service;

            public UiLayer(OrderService service)
            {
                _service = service;
            }

            public void ShowOrders()
            {
                var orders = _service.GetAllOrders();
                foreach (var order in orders)
                {
                    Console.WriteLine($"Order {order.Id}: {order.ProductName}");
                }
            }
        }

        public class OrderService
        {
            private readonly OrderRepository _repository = new OrderRepository();

            public Order[] GetAllOrders()
            {
                return _repository.FetchOrders();
            }
        }

        public class OrderRepository
        {
            public Order[] FetchOrders()
            {
                return new[]
                {
                    new Order { Id = 1, ProductName = "Laptop" },
                    new Order { Id = 2, ProductName = "Phone" }
                };
            }
        }

        public class Order
        {
            public int Id { get; set; }
            public string ProductName { get; set; } = string.Empty;
        }
    }
}
