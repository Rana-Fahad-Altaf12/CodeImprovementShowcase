using Improvements.Common.Interfaces;
using System;

namespace Improvements._49_PoorModularBoundaries.Bad
{
    public class TightlyCoupledModules : IImprovementDemo
    {
        public void Run()
        {
            var orderProcessor = new OrderProcessor();
            orderProcessor.Process();
        }

        public class OrderProcessor
        {
            private readonly EmailService _emailService = new EmailService(); // Tight coupling to concrete class

            public void Process()
            {
                Console.WriteLine("Processing Order...");
                _emailService.SendEmail("Order processed.");
            }
        }

        public class EmailService
        {
            public void SendEmail(string message)
            {
                Console.WriteLine($"Sending email: {message}");
            }
        }
    }
}
