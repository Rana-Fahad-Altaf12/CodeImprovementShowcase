using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Improvements.Common.Data;
using Improvements.Common.Models;
using Improvements.Common.Interfaces;

namespace Improvements._06_UnnecessarySelectVsDirectUse.Good
{
    public class DirectAccessExample : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Running Good Example (Direct property access)");

            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("Good_DirectSelect"));
            services.AddScoped<UserService>();
            services.AddScoped<ProjectionService>();
            using var provider = services.BuildServiceProvider();
            using var scope = provider.CreateScope();

            var userService = scope.ServiceProvider.GetRequiredService<UserService>();
            SeedUsers(userService);

            var projectionService = scope.ServiceProvider.GetRequiredService<ProjectionService>();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            long memoryBefore = GC.GetTotalMemory(true);
            var stopwatch = Stopwatch.StartNew();

            var users = projectionService.GetUsersDirectly();
            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine($"Users Returned: {users.Count}");
            Console.WriteLine($"First User Name: {users.First()}");
            Console.WriteLine($"Time Taken: {stopwatch.Elapsed.TotalMilliseconds:N2} ms");
            Console.WriteLine($"Memory Used: {(memoryAfter - memoryBefore) / 1024.0:N2} KB");
        }

        private void SeedUsers(UserService service)
        {
            for (int i = 0; i < 10000; i++)
            {
                service.Add(new User { Name = $"User{i}" });
            }
            service.Save();
        }
    }
}
