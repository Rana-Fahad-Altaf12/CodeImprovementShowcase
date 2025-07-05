using Improvements.Common.Interfaces;
using System.Diagnostics;

namespace Improvements._11_StringBuilderVsStringConcat.Bad
{
    public class StringConcatExample : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            string result = "";
            for (int i = 0; i < 50_000; i++)
            {
                result += "x";
            }

            long memoryAfter = GC.GetTotalMemory(true);
            stopwatch.Stop();

            Console.WriteLine($"Length: {result.Length}");
            Console.WriteLine($"[Bad] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {memoryAfter - memoryBefore} bytes");
        }
    }
}
