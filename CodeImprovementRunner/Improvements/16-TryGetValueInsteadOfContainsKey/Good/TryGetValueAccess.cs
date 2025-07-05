using Improvements.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Improvements._16_TryGetValueInsteadOfContainsKey.Good
{
    public class TryGetValueAccess : IImprovementDemo
    {
        public void Run()
        {
            var dict = GenerateRoles();

            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            for (int i = 0; i < 100000; i++)
            {
                if (dict.TryGetValue("admin", out var role))
                {
                    Consume(role);
                }
            }

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);
            Console.WriteLine($"[Good] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {Math.Max(0, memoryAfter - memoryBefore)} bytes");
        }

        private Dictionary<string, string> GenerateRoles()
        {
            return new Dictionary<string, string>
            {
                ["admin"] = "Administrator",
                ["user"] = "Regular User",
                ["guest"] = "Guest User"
            };
        }

        private void Consume(string value)
        {
            if (value.Length == -1)
                Console.WriteLine("Impossible");
        }
    }
}
