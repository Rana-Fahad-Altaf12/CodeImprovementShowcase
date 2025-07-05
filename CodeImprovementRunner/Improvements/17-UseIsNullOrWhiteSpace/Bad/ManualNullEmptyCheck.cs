using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._17_UseIsNullOrWhiteSpace.Bad
{
    public class ManualNullEmptyCheck : IImprovementDemo
    {
        public void Run()
        {
            string name = "   ";

            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            bool isValid = name != null && name.Trim() != "";

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine($"Name valid? {isValid}");
            Console.WriteLine($"[Bad] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {memoryAfter - memoryBefore} bytes");
        }
    }
}
