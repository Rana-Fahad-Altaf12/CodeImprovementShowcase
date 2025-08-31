using Improvements.Common.Interfaces;
using System;
using System.IO;

namespace Improvements._82_FileReadAllTextForLargeFiles.Good
{
    public class ReadFileStreamEfficiently : IImprovementDemo
    {
        public void Run()
        {
            // Good: read file line by line to avoid large memory allocation
            var path = "largefile.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("File not found.");
                return;
            }

            long totalChars = 0;
            using var reader = new StreamReader(path);
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                totalChars += line.Length;
            }

            Console.WriteLine($"Total characters in file: {totalChars}");
        }
    }
}
