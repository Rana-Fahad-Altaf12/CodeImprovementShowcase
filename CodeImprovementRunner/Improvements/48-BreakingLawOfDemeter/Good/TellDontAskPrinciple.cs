using Improvements.Common.Interfaces;
using System;

namespace Improvements._48_BreakingLawOfDemeter.Good
{
    public class TellDontAskPrinciple : IImprovementDemo
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

            Console.WriteLine($"Shipping to: {order.GetShippingCity()}");
        }

        public class Order
        {
            public Customer Customer { get; set; }

            public string GetShippingCity() => Customer?.GetCity();
        }

        public class Customer
        {
            public Address Address { get; set; }

            public string GetCity() => Address?.City;
        }

        public class Address
        {
            public string City { get; set; }
        }
    }
}
