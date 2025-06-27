using System;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Improvements.Common.Interfaces;
using Improvements.Common.Models;

namespace Improvements._10_ToListBeforeVsAfterFilter.Good
{
    public class DeferredToListExample : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Running Good Example (Filter before ToList())");

            var services = new ServiceCollection();
            services.AddScoped<DataProcessor>();
            using var provider = services.BuildServiceProvider();
            using var scope = provider.CreateScope();

            var processor = scope.ServiceProvider.GetRequiredService<DataProcessor>();
            var data = GenerateTestData();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            long memoryBefore = GC.GetTotalMemory(true);
            var sw = Stopwatch.StartNew();

            // Filter first, then materialize the results
            var result = processor.FilterBeforeToList(data);

            sw.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine($"Filtered Count: {result.Count}");
            Console.WriteLine($"Time Taken: {sw.Elapsed.TotalMilliseconds:N2} ms");
            Console.WriteLine($"Memory Used: {(memoryAfter - memoryBefore) / 1024.0:N2} KB");
        }

        private static List<User> GenerateTestData()
        {
            var list = new List<User>();
            for (int i = 0; i < 100000; i++)
            {
                list.Add(new User { Name = i % 2 == 0 ? "Alice" : "Bob" });
            }
            return list;
        }
    }
}
