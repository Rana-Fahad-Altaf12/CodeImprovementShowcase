using Improvements.Common.Data;
using Improvements.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;

namespace Improvements._03_AnyVsFirstOrDefault.Bad
{
    public class FirstOrDefaultExample : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Running Bad Example (FirstOrDefault)");

            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("BadFirstOrDefaultDb"));
            services.AddScoped<UserService>();

            using var provider = services.BuildServiceProvider();
            using var scope = provider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<UserService>();

            for (int i = 0; i < 10000; i++)
                service.Add(new Common.Models.User { Name = i == 9999 ? "Alice" : $"User{i}" });

            var sw = Stopwatch.StartNew();
            // Fixed the error by using LINQ's FirstOrDefault on the Queryable collection
            var user = service.Query().FirstOrDefault(u => u.Name == "Alice");
            sw.Stop();

            Console.WriteLine($"User Exists: {user != null}");
            Console.WriteLine($"⏱ Time Taken (FirstOrDefault): {sw.Elapsed.TotalMilliseconds:N2} ms");
        }
    }
}