using Improvements.Common.Interfaces;
using System;

namespace Improvements._49_PoorModularBoundaries.Good
{
    public class DecoupledModulesWithInterfaces : IImprovementDemo
    {
        public void Run()
        {
            INotificationService notifier = new EmailNotificationService();
            var orderProcessor = new OrderProcessor(notifier);
            orderProcessor.Process();
        }

        public class OrderProcessor
        {
            private readonly INotificationService _notifier;

            public OrderProcessor(INotificationService notifier)
            {
                _notifier = notifier;
            }

            public void Process()
            {
                Console.WriteLine("Processing Order...");
                _notifier.Notify("Order processed.");
            }
        }

        public interface INotificationService
        {
            void Notify(string message);
        }

        public class EmailNotificationService : INotificationService
        {
            public void Notify(string message)
            {
                Console.WriteLine($"[EMAIL] {message}");
            }
        }
    }
}
