using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._52_LoggingSensitiveData.Good
{
    public class SecureLogging : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("=== GOOD: Secure Logging ===");

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
                // GOOD: Avoid logging sensitive data, only log safe details
                Console.WriteLine($"Login failed for user={username}, error={ex.Message}");
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
