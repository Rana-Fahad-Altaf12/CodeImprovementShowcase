using Improvements.Common.Interfaces;
using System;

namespace Improvements._78_BreakingLawOfDemeter.Bad
{
    public class LawOfDemeterViolation : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Bad: Calling chained properties (violates Law of Demeter)");

            var order = new Order
            {
                Customer = new Customer
                {
                    Address = new Address
                    {
                        City = "New York"
                    }
                }
            };

            // Chained access
            Console.WriteLine($"Customer city: {order.Customer.Address.City}");
        }

        public class Order
        {
            public Customer Customer { get; set; } = new Customer();
        }

        public class Customer
        {
            public Address Address { get; set; } = new Address();
        }

        public class Address
        {
            public string City { get; set; } = string.Empty;
        }
    }
}
