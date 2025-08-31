using Improvements.Common.Interfaces;
using System;
using System.IO;

namespace Improvements._90_TempFilesWithoutCleanup.Good
{
    public class TempFileWithCleanup : IImprovementDemo
    {
        public void Run()
        {
            string tempPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            try
            {
                File.WriteAllText(tempPath, "Temporary data");
                Console.WriteLine($"Temp file created at: {tempPath}");

                // Do work with the temp file
            }
            finally
            {
                // Ensure cleanup
                if (File.Exists(tempPath))
                {
                    File.Delete(tempPath);
                    Console.WriteLine("Temp file deleted safely.");
                }
            }
        }
    }
}
