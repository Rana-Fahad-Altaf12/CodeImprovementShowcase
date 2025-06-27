using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Improvements.Common.Interfaces;

namespace Improvements._04_ResultVsAwait.Good
{
    public class AwaitExample : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Running Good Example (await)");

            var services = new ServiceCollection();
            services.AddScoped<AsyncDemoService>();
            var provider = services.BuildServiceProvider();

            var task = RunAsync(provider);
            task.Wait(); // This is fine here, since it's a console runner
        }

        private async Task RunAsync(IServiceProvider provider)
        {
            var service = provider.GetRequiredService<AsyncDemoService>();

            var start = DateTime.Now;
            var result = await service.GetDataAsync(); // Non-blocking
            var end = DateTime.Now;

            Console.WriteLine($"Result: {result}");
            Console.WriteLine($"⏱ Time Taken (Await): {(end - start).TotalMilliseconds:N2} ms");
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
