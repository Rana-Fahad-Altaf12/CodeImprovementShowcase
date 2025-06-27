using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Improvements.Common.Data;
using Improvements.Common.Models;
using Improvements.Common.Interfaces;

namespace Improvements._05_MultipleToListCalls.Good
{
    public class ChainedLinqExample : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Running Good Example (Chained LINQ)");

            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("GoodChainedLinq"));
            services.AddScoped<UserService>();
            services.AddScoped<ToListBenchmarkService>();
            using var provider = services.BuildServiceProvider();
            using var scope = provider.CreateScope();

            var userService = scope.ServiceProvider.GetRequiredService<UserService>();
            SeedUsers(userService);

            var benchmarkService = scope.ServiceProvider.GetRequiredService<ToListBenchmarkService>();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            long memoryBefore = GC.GetTotalMemory(true);
            var stopwatch = Stopwatch.StartNew();

            var users = benchmarkService.GetUsersWithChainedLinq();
            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine($"Users Returned: {users.Count}");
            Console.WriteLine($"Time Taken: {stopwatch.Elapsed.TotalMilliseconds:N2} ms");
            Console.WriteLine($"Memory Used: {(memoryAfter - memoryBefore) / 1024.0:N2} KB");
        }

        private void SeedUsers(UserService service)
        {
            for (int i = 0; i < 10000; i++)
                service.Add(new User { Name = i % 2 == 0 ? "Alice" : "Bob" });
            service.Save();
        }
    }

    public class ToListBenchmarkService
    {
        private readonly AppDbContext _context;
        public ToListBenchmarkService(AppDbContext context) => _context = context;

        public List<string> GetUsersWithChainedLinq()
        {
            return _context.Users
                .Where(u => u.Name == "Alice")
                .Select(u => u.Name)
                .ToList(); // Single ToList at the end
        }
    }
}
