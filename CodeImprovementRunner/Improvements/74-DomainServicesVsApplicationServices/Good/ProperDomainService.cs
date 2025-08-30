using Improvements.Common.Interfaces;
using System;

namespace Improvements._74_DomainServicesVsApplicationServices.Good
{
    public class ProperDomainService : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Good: Business logic in domain service");

            var orderDomainService = new OrderDomainService();
            var orderAppService = new OrderAppService(orderDomainService);

            orderAppService.PlaceOrder(1, 5);
        }
    }

    public class OrderDomainService
    {
        public bool CanPlaceOrder(int quantity)
        {
            return quantity > 0;
        }
    }

    public class OrderAppService
    {
        private readonly OrderDomainService _domainService;

        public OrderAppService(OrderDomainService domainService)
        {
            _domainService = domainService;
        }

        public void PlaceOrder(int customerId, int quantity)
        {
            if (!_domainService.CanPlaceOrder(quantity))
            {
                Console.WriteLine("Cannot place order with zero or negative quantity.");
                return;
            }

            Console.WriteLine($"Order placed for Customer {customerId} with quantity {quantity}");
        }
    }
}
