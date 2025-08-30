using Improvements.Common.Interfaces;
using System;

namespace Improvements._55_RethrowingExceptions.Bad
{
    public class RethrowWithEx : IImprovementDemo
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
                // BAD: resets the stack trace
                throw ex;
            }
        }

        private void CauseError()
        {
            throw new InvalidOperationException("Something went wrong!");
        }
    }
}
