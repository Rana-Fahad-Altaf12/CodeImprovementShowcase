using Improvements.Common.Data;
using Improvements.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;

namespace Improvements._03_AnyVsFirstOrDefault.Good
{
    public class AnyExample : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Running Good Example (Any)");

            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("GoodAnyDb"));
            services.AddScoped<UserService>();

            using var provider = services.BuildServiceProvider();
            using var scope = provider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<UserService>();

            for (int i = 0; i < 10000; i++)
                service.Add(new Common.Models.User { Name = i == 9999 ? "Alice" : $"User{i}" });

            var sw = Stopwatch.StartNew();
            var exists = service.Query().Any(u => u.Name == "Alice");
            sw.Stop();

            Console.WriteLine($"User Exists: {exists}");
            Console.WriteLine($"⏱ Time Taken (Any): {sw.Elapsed.TotalMilliseconds:N2} ms");
        }
    }
}