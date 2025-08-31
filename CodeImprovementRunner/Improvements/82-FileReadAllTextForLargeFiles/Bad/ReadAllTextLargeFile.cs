using Improvements.Common.Interfaces;
using System;
using System.IO;

namespace Improvements._82_FileReadAllTextForLargeFiles.Bad
{
    public class ReadAllTextLargeFile : IImprovementDemo
    {
        public void Run()
        {
            // Bad: reading a very large file entirely into memory
            var path = "largefile.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("File not found.");
                return;
            }

            string content = File.ReadAllText(path);
            Console.WriteLine($"File length: {content.Length}");
        }
    }
}
