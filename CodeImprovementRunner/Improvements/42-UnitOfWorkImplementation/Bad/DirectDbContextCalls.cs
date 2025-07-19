using Improvements.Common.Interfaces;
using System;

namespace Improvements._42_UnitOfWorkImplementation.Bad
{
    public class DirectDbContextCalls : IImprovementDemo
    {
        public void Run()
        {
            var context = new FakeDbContext();
            context.Users.Add(new User { Name = "Alice" });
            context.SaveChanges();

            context.Orders.Add(new Order { UserId = 1, Amount = 99 });
            context.SaveChanges();

            Console.WriteLine("User and order saved separately without transaction.");
        }
    }

    public class FakeDbContext
    {
        public FakeDbSet<User> Users { get; set; } = new();
        public FakeDbSet<Order> Orders { get; set; } = new();
        public void SaveChanges() { /* Simulate DB commit */ }
    }

    public class FakeDbSet<T> where T : class
    {
        public void Add(T entity) { /* Simulate adding */ }
    }

    public class User { public string Name { get; set; } }
    public class Order { public int UserId { get; set; } public decimal Amount { get; set; } }
}
