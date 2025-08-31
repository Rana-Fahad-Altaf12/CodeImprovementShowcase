using Improvements.Common.Interfaces;
using System;
using System.Text.Json;

namespace Improvements._88_BinaryFormatterUsage.Good
{
    public class SafeSerialization : IImprovementDemo
    {
        public void Run()
        {
            var obj = new Person { Name = "Fahad", Age = 30 };

            // Serialize safely with System.Text.Json
            string json = JsonSerializer.Serialize(obj);
            Console.WriteLine($"JSON Output: {json}");

            // Deserialize safely
            var deserialized = JsonSerializer.Deserialize<Person>(json);
            Console.WriteLine($"Deserialized Name: {deserialized.Name}");
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
