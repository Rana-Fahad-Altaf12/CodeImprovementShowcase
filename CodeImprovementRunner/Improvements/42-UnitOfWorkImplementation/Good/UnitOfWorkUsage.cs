using Improvements.Common.Interfaces;
using System;

namespace Improvements._42_UnitOfWorkImplementation.Good
{
    public class UnitOfWorkUsage : IImprovementDemo
    {
        public void Run()
        {
            var unitOfWork = new FakeUnitOfWork();

            unitOfWork.Users.Add(new User { Name = "Alice" });
            unitOfWork.Orders.Add(new Order { UserId = 1, Amount = 99 });

            unitOfWork.Complete();

            Console.WriteLine("User and order saved together in single transaction.");
        }
    }

    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IOrderRepository Orders { get; }
        void Complete();
    }

    public class FakeUnitOfWork : IUnitOfWork
    {
        public IUserRepository Users { get; } = new UserRepository();
        public IOrderRepository Orders { get; } = new OrderRepository();

        public void Complete()
        {
            // Simulate single transaction
        }
    }

    public interface IUserRepository
    {
        void Add(User user);
    }

    public interface IOrderRepository
    {
        void Add(Order order);
    }

    public class UserRepository : IUserRepository
    {
        public void Add(User user) { /* Simulate adding */ }
    }

    public class OrderRepository : IOrderRepository
    {
        public void Add(Order order) { /* Simulate adding */ }
    }

    public class User { public string Name { get; set; } }
    public class Order { public int UserId { get; set; } public decimal Amount { get; set; } }
}
