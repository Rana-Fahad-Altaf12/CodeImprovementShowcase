using Improvements.Common.Interfaces;
using System;

namespace Improvements._51_SwallowingExceptions.Bad
{
    public class SilentException : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Starting process (Bad)...");

            try
            {
                DangerousOperation();
            }
            catch
            {
                // Swallowed exception – nothing is logged, no rethrow
            }

            Console.WriteLine("Process completed (but errors may have been hidden).");
        }

        private void DangerousOperation()
        {
            throw new InvalidOperationException("Something went wrong in DangerousOperation!");
        }
    }
}
