using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._52_LoggingSensitiveData.Bad
{
    public class LoggingSensitiveInfo : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("=== BAD: Logging Sensitive Data ===");

            var username = "john.doe";
            var password = "SuperSecret123!";

            long beforeMemory = GC.GetTotalMemory(true);
            var sw = Stopwatch.StartNew();

            try
            {
                Authenticate(username, password);
            }
            catch (Exception ex)
            {
                // BAD: Logging raw sensitive information
                Console.WriteLine($"Login failed for user={username}, password={password}, error={ex.Message}");
            }

            sw.Stop();
            long afterMemory = GC.GetTotalMemory(false);

            Console.WriteLine($"Time: {sw.ElapsedMilliseconds} ms, Memory Used: {afterMemory - beforeMemory} bytes");
            Console.WriteLine();
        }

        private static void Authenticate(string user, string pass)
        {
            // Fake authentication failure
            throw new Exception("Invalid credentials");
        }
    }
}
