using Improvements.Common.Interfaces;
using System;

namespace Improvements._77_CleanArchitectureLayeringMistake.Bad
{
    public class LayerViolation : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Bad: UI layer directly accessing repository");

            var ui = new UiLayer();
            ui.ShowOrders();
        }

        public class UiLayer
        {
            private readonly OrderRepository _repository = new OrderRepository();

            public void ShowOrders()
            {
                var orders = _repository.GetOrders();
                foreach (var order in orders)
                {
                    Console.WriteLine($"Order {order.Id}: {order.ProductName}");
                }
            }
        }

        public class OrderRepository
        {
            public Order[] GetOrders()
            {
                // Simulated DB fetch
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
