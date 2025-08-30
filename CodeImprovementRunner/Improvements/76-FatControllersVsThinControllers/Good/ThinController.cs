using Improvements.Common.Interfaces;
using System;

namespace Improvements._76_FatControllersVsThinControllers.Good
{
    public class ThinController : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Good: Thin controller delegates responsibilities");

            var controller = new OrderController(
                new OrderService(),
                new EmailService(),
                new LoggerService()
            );

            controller.CreateOrder(1, 5);
        }

        public class OrderController
        {
            private readonly OrderService _orderService;
            private readonly EmailService _emailService;
            private readonly LoggerService _loggerService;

            public OrderController(OrderService orderService, EmailService emailService, LoggerService loggerService)
            {
                _orderService = orderService;
                _emailService = emailService;
                _loggerService = loggerService;
            }

            public void CreateOrder(int customerId, int quantity)
            {
                if (!_orderService.ValidateOrder(quantity))
                    return;

                _orderService.PlaceOrder(customerId, quantity);
                _emailService.SendConfirmation(customerId);
                _loggerService.Log($"Order created for customer {customerId}");
            }
        }

        public class OrderService
        {
            public bool ValidateOrder(int quantity)
            {
                if (quantity <= 0)
                {
                    Console.WriteLine("Invalid quantity.");
                    return false;
                }
                return true;
            }

            public void PlaceOrder(int customerId, int quantity)
            {
                Console.WriteLine($"Processing order for customer {customerId}, quantity {quantity}...");
                Console.WriteLine("Saving order to database...");
            }
        }

        public class EmailService
        {
            public void SendConfirmation(int customerId)
            {
                Console.WriteLine("Sending confirmation email...");
            }
        }

        public class LoggerService
        {
            public void Log(string message)
            {
                Console.WriteLine($"LOG: {message}");
            }
        }
    }
}
