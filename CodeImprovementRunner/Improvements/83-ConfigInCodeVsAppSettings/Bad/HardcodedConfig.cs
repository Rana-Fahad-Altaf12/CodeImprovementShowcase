using Improvements.Common.Interfaces;
using System;

namespace Improvements._83_ConfigInCodeVsAppSettings.Bad
{
    public class HardcodedConfig : IImprovementDemo
    {
        public void Run()
        {
            // Bad: configuration hardcoded in code
            string connectionString = "Server=.;Database=MyDb;User Id=sa;Password=1234;";
            int retryCount = 5;

            Console.WriteLine($"Connection: {connectionString}, RetryCount: {retryCount}");
        }
    }
}
