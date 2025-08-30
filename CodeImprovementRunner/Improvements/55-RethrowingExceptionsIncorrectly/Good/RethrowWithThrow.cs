using Improvements.Common.Interfaces;
using System;

namespace Improvements._55_RethrowingExceptions.Good
{
    public class RethrowWithThrow : IImprovementDemo
    {
        public void Run()
        {
            try
            {
                CauseError();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error caught: " + ex.Message);
                // GOOD: preserves the original stack trace
                throw;
            }
        }

        private void CauseError()
        {
            throw new InvalidOperationException("Something went wrong!");
        }
    }
}
