using Improvements.Common.Interfaces;
using System.Diagnostics;
using System.Text;

namespace Improvements._11_StringBuilderVsStringConcat.Good
{
    public class StringBuilderExample : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            var sb = new StringBuilder();
            for (int i = 0; i < 50_000; i++)
            {
                sb.Append("x");
            }

            string result = sb.ToString();

            long memoryAfter = GC.GetTotalMemory(true);
            stopwatch.Stop();

            Console.WriteLine($"Length: {result.Length}");
            Console.WriteLine($"[Good] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {memoryAfter - memoryBefore} bytes");
        }
    }
}
