using Improvements.Common.Interfaces;
using System;
using System.Buffers;
using System.Diagnostics;

namespace Improvements._22_AvoidLargeObjectHeap.Good
{
    public class UseArrayPooling : IImprovementDemo
    {
        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();
            long memoryBefore = GC.GetTotalMemory(true);

            byte[] rentedArray = ArrayPool<byte>.Shared.Rent(100_000);

            try
            {
                rentedArray[0] = 1; // simulate usage
                Console.WriteLine($"Rented array length: {rentedArray.Length}");
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(rentedArray);
            }

            stopwatch.Stop();
            long memoryAfter = GC.GetTotalMemory(true);
            Console.WriteLine($"[Good] Time: {stopwatch.ElapsedMilliseconds}ms, Memory: {Math.Max(0, memoryAfter - memoryBefore)} bytes");
        }
    }
}
