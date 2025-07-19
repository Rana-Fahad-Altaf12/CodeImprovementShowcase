using Improvements.Common.Interfaces;
using System;

namespace Improvements._48_BreakingLawOfDemeter.Bad
{
    public class TightlyCoupledChain : IImprovementDemo
    {
        public void Run()
        {
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

            var city = order.Customer.Address.City; // Deep chaining
            Console.WriteLine($"Shipping to: {city}");
        }

        public class Order
        {
            public Customer Customer { get; set; }
        }

        public class Customer
        {
            public Address Address { get; set; }
        }

        public class Address
        {
            public string City { get; set; }
        }
    }
}
