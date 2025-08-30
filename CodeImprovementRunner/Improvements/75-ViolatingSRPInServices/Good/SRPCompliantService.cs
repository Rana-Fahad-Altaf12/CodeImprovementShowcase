using Improvements.Common.Interfaces;
using System;

namespace Improvements._75_ViolatingSRPInServices.Good
{
    public class SRPCompliantService : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Good: Single Responsibility Principle applied");

            var orderValidator = new OrderValidator();
            var paymentProcessor = new PaymentProcessor();
            var emailSender = new EmailSender();

            var customerId = 1;
            var quantity = 10;

            if (!orderValidator.Validate(quantity))
                return;

            paymentProcessor.ProcessPayment(customerId, quantity);
            emailSender.SendConfirmation(customerId);
        }

        public class OrderValidator
        {
            public bool Validate(int quantity)
            {
                if (quantity <= 0)
                {
                    Console.WriteLine("Invalid order quantity.");
                    return false;
                }
                return true;
            }
        }

        public class PaymentProcessor
        {
            public void ProcessPayment(int customerId, int quantity)
            {
                Console.WriteLine($"Charging customer {customerId} for {quantity} items...");
            }
        }

        public class EmailSender
        {
            public void SendConfirmation(int customerId)
            {
                Console.WriteLine($"Sending confirmation email to customer {customerId}...");
            }
        }
    }
}
