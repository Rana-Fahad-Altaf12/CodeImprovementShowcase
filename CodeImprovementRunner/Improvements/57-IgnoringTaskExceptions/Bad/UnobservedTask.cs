using Improvements.Common.Interfaces;
using System;
using System.Threading.Tasks;

namespace Improvements._57_IgnoringTaskExceptions.Bad
{
    public class UnobservedTask : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Bad: Ignoring task exceptions...");

            Task.Run(() =>
            {
                throw new InvalidOperationException("Something went wrong in background task.");
            });

            // No await, no Wait(), no ContinueWith – exception is unobserved.
            // In .NET, unobserved task exceptions can crash the process or get lost.
            Task.Delay(1000).Wait();

            Console.WriteLine("Task completed, but exception was ignored.");
        }
    }
}
