using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Improvements.Common.Data;
using Improvements.Common.Models;
using Improvements.Common.Interfaces;

namespace Improvements._01_DbContextLifetime.Good
{
    public class ScopedDbContextExample : IImprovementDemo
    {
        public void Run()
        {
            var services = new ServiceCollection();

            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("ScopedDb"));
            services.AddScoped<UserService>();

            var provider = services.BuildServiceProvider();

            Console.WriteLine("Running Good Example (Scoped DbContext)");

            using var scope = provider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<UserService>();

            service.Add(new User { Name = "User A" });
            service.Add(new User { Name = "User B" });

            Console.WriteLine($"✅ Total Users: {service.Count()}");
        }
    }
}