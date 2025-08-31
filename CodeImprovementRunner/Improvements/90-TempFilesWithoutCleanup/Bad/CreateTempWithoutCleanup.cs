using Improvements.Common.Interfaces;
using System;
using System.IO;

namespace Improvements._90_TempFilesWithoutCleanup.Bad
{
    public class CreateTempWithoutCleanup : IImprovementDemo
    {
        public void Run()
        {
            string tempPath = Path.GetTempFileName();

            File.WriteAllText(tempPath, "Temporary data");

            Console.WriteLine($"Temp file created at: {tempPath}");

            // No cleanup performed
            Console.WriteLine("Temp file not deleted, may accumulate over time.");
        }
    }
}
