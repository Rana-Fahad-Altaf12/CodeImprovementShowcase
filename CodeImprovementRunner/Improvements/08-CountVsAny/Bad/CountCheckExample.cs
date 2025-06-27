using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Improvements.Common.Data;
using Improvements.Common.Models;
using Improvements.Common.Interfaces;

namespace Improvements._08_CountVsAny.Bad
{
    public class CountCheckExample : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Running Bad Example (Count() > 0)");

            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("Bad_CountCheck"));
            services.AddScoped<UserService>();
            services.AddScoped<ExistenceCheckService>();
            using var provider = services.BuildServiceProvider();
            using var scope = provider.CreateScope();

            var userService = scope.ServiceProvider.GetRequiredService<UserService>();
            SeedUsers(userService);

            var checker = scope.ServiceProvider.GetRequiredService<ExistenceCheckService>();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            long memoryBefore = GC.GetTotalMemory(true);
            var sw = Stopwatch.StartNew();

            bool exists = checker.CheckUsingCount();
            sw.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine($"Exists: {exists}");
            Console.WriteLine($"Time Taken: {sw.Elapsed.TotalMilliseconds:N2} ms");
            Console.WriteLine($"Memory Used: {(memoryAfter - memoryBefore) / 1024.0:N2} KB");
        }

        private void SeedUsers(UserService service)
        {
            for (int i = 0; i < 10000; i++)
            {
                service.Add(new User { Name = i % 2 == 0 ? "Alice" : "Bob" });
            }
            service.Save();
        }
    }
}
