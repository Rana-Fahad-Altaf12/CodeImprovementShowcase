using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Improvements.Common.Interfaces;

namespace Improvements._04_ResultVsAwait.Bad
{
    public class BlockingExample : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Running Bad Example (.Result / .Wait())");

            var services = new ServiceCollection();
            services.AddScoped<AsyncDemoService>();
            var provider = services.BuildServiceProvider();

            var service = provider.GetRequiredService<AsyncDemoService>();

            try
            {
                var start = DateTime.Now;
                var result = service.GetDataAsync().Result; // Blocks the thread
                var end = DateTime.Now;

                Console.WriteLine($"Result: {result}");
                Console.WriteLine($"⏱ Time Taken (Blocking): {(end - start).TotalMilliseconds:N2} ms");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    public class AsyncDemoService
    {
        public async Task<string> GetDataAsync()
        {
            await Task.Delay(1000); // Simulate I/O
            return "Hello from async task!";
        }
    }
}
