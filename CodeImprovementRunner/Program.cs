using Improvements.Common.Interfaces;
using Improvements.Common.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CodeImprovementRunner
{
    internal class Program
    {
        // Load dictionary at startup
        private static readonly Dictionary<string, (string Title, Type Bad, Type Good)> improvements = LoadImprovements();

        static Dictionary<string, (string Title, Type Bad, Type Good)> LoadImprovements()
        {
            var basePath = AppContext.BaseDirectory;
            var fullPath = Path.Combine(basePath, "Config", "improvements.json");
            var json = File.ReadAllText(fullPath);

            var rawList = JsonSerializer.Deserialize<List<ImprovementMetadata>>(json)!;

            return rawList.ToDictionary(
                x => x.Id,
                x => (
                    x.Title,
                    Type.GetType(x.Bad) ?? throw new InvalidOperationException($"Bad type not found: {x.Bad}"),
                    Type.GetType(x.Good) ?? throw new InvalidOperationException($"Good type not found: {x.Good}")
                )
            );
        }

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("== Code Improvement Showcase ==\n");

                // Now this will work
                foreach (var entry in improvements)
                {
                    Console.WriteLine($"[{entry.Key}] {entry.Value.Title}");
                }

                Console.Write("\nEnter improvement number to run (or 'q' to quit): ");
                var input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be null or empty. Press any key to retry...");
                    Console.ReadKey();
                    continue;
                }

                if (string.Equals(input, "q", StringComparison.OrdinalIgnoreCase))
                    break;

                if (improvements.TryGetValue(input, out var demo))
                {
                    Console.WriteLine($"\n--- Running: {demo.Title} ---\n");

                    Console.WriteLine("Bad Implementation:");
                    RunDemo(demo.Bad);

                    Console.WriteLine("\nGood Implementation:");
                    RunDemo(demo.Good);

                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Invalid option. Press any key to retry...");
                    Console.ReadKey();
                }
            }
        }

        static void RunDemo(Type demoType)
        {
            if (Activator.CreateInstance(demoType) is IImprovementDemo demo)
            {
                try { demo.Run(); }
                catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
            }
            else
            {
                Console.WriteLine("Demo class must implement IImprovementDemo.");
            }
        }
    }
}
