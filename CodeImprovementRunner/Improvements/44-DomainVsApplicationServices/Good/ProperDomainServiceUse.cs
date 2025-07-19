using Improvements.Common.Interfaces;
using System;

namespace Improvements._44_DomainVsApplicationServices.Good
{
    public class ProperDomainServiceUse : IImprovementDemo
    {
        public void Run()
        {
            var order = new Order(500, false);
            var discountService = new DiscountDomainService();
            var appService = new OrderApplicationService(discountService);
            var result = appService.CheckDiscountEligibility(order);

            Console.WriteLine($"Discount allowed (with domain service): {result}");
        }

        public class Order
        {
            public decimal Amount { get; }
            public bool IsDiscounted { get; }

            public Order(decimal amount, bool isDiscounted)
            {
                Amount = amount;
                IsDiscounted = isDiscounted;
            }
        }

        public class DiscountDomainService
        {
            public bool CanApplyDiscount(Order order)
            {
                return order.Amount > 300 && !order.IsDiscounted;
            }
        }

        public class OrderApplicationService
        {
            private readonly DiscountDomainService _domainService;

            public OrderApplicationService(DiscountDomainService domainService)
            {
                _domainService = domainService;
            }

            public bool CheckDiscountEligibility(Order order)
            {
                return _domainService.CanApplyDiscount(order);
            }
        }
    }
}
