using Improvements.Common.Interfaces;
using System;

namespace Improvements._78_BreakingLawOfDemeter.Good
{
    public class LawOfDemeterCompliant : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Good: Exposing method/property to reduce chaining");

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

            Console.WriteLine($"Customer city: {order.GetCustomerCity()}");
        }

        public class Order
        {
            public Customer Customer { get; set; } = new Customer();

            public string GetCustomerCity() => Customer.GetCity();
        }

        public class Customer
        {
            public Address Address { get; set; } = new Address();

            public string GetCity() => Address.City;
        }

        public class Address
        {
            public string City { get; set; } = string.Empty;
        }
    }
}
