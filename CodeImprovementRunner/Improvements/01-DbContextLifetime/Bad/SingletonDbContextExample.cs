using Improvements.Common.Data;
using Improvements.Common.Interfaces;
using Improvements.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Improvements._01_DbContextLifetime.Bad
{
    public class SingletonDbContextExample : IImprovementDemo
    {
        public void Run()
        {
            var services = new ServiceCollection();

            services.AddSingleton<AppDbContext>(provider =>
            {
                var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase("SingletonDb")
                    .Options;
                return new AppDbContext(options);
            });

            services.AddSingleton<UserService>();

            var provider = services.BuildServiceProvider();
            var service = provider.GetRequiredService<UserService>();

            Console.WriteLine("Running Bad Example (Singleton DbContext)");

            try
            {
                Parallel.For(0, 10, i => service.Add(new User { Name = $"User {i}" }));
                Console.WriteLine($"✅ Final User Count: {service.Count()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Exception: {ex.Message}");
            }
        }
    }
}