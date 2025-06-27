using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Improvements.Common.Data;
using Improvements.Common.Models;
using Improvements.Common.Interfaces;

namespace Improvements._02_IEnumerableVsIQueryable.Bad
{
    public class IEnumerableExample : IImprovementDemo
    {
        public void Run()
        {
            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("EnumerableDb"));
            services.AddScoped<UserService>();

            using var provider = services.BuildServiceProvider();
            using var scope = provider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<UserService>();

            SeedUsers(service);

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            long before = GC.GetTotalMemory(true);

            var users = service.All().Where(u => u.Name.StartsWith("A")).ToList();

            long after = GC.GetTotalMemory(true);
            Console.WriteLine($"Memory Used (IEnumerable): {(after - before) / 1024.0:N2} KB");
        }

        private void SeedUsers(UserService service)
        {
            for (int i = 0; i < 1000; i++)
                service.Add(new User { Name = i % 2 == 0 ? "Alice" : "Bob" });
        }
    }
}