using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Improvements.Common.Data;
using Improvements.Common.Models;
using Improvements.Common.Interfaces;

namespace Improvements._07_OrConditionsVsContains.Good
{
    public class ContainsExample : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Running Good Example (Using .Contains())");

            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("Good_Contains"));
            services.AddScoped<UserService>();
            services.AddScoped<FilterService>();
            using var provider = services.BuildServiceProvider();
            using var scope = provider.CreateScope();

            var userService = scope.ServiceProvider.GetRequiredService<UserService>();
            SeedUsers(userService);

            var filterService = scope.ServiceProvider.GetRequiredService<FilterService>();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            long memoryBefore = GC.GetTotalMemory(true);
            var sw = Stopwatch.StartNew();

            var result = filterService.FilterUsersUsingContains();
            sw.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine($"Users Returned: {result.Count}");
            Console.WriteLine($"First Match: {result.First()}");
            Console.WriteLine($"Time Taken: {sw.Elapsed.TotalMilliseconds:N2} ms");
            Console.WriteLine($"Memory Used: {(memoryAfter - memoryBefore) / 1024.0:N2} KB");
        }

        private void SeedUsers(UserService service)
        {
            for (int i = 0; i < 10000; i++)
            {
                var name = (i % 4) switch
                {
                    0 => "Alice",
                    1 => "Bob",
                    2 => "Charlie",
                    _ => "Eve"
                };
                service.Add(new User { Name = name });
            }
            service.Save();
        }
    }
}
