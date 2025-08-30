using Improvements.Common.Interfaces;
using System;
using System.Threading.Tasks;

namespace Improvements._57_IgnoringTaskExceptions.Good
{
    public class ObservedTask : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Good: Observing task exceptions...");

            try
            {
                var task = Task.Run(() =>
                {
                    throw new InvalidOperationException("Something went wrong in background task.");
                });

                task.Wait(); // or await in async context
            }
            catch (AggregateException ex)
            {
                foreach (var inner in ex.InnerExceptions)
                {
                    Console.WriteLine($"Handled exception: {inner.Message}");
                }
            }
        }
    }
}
