using Improvements.Common.Interfaces;
using System;
using System.Text.Json;

namespace Improvements._85_DynamicJsonDeserialization.Good
{
    public class StronglyTypedDeserialization : IImprovementDemo
    {
        public void Run()
        {
            string json = "{\"Name\":\"Fahad\",\"Age\":30}";
            var obj = JsonSerializer.Deserialize<Person>(json)!;
            Console.WriteLine($"Name: {obj.Name}, Age: {obj.Age}");
        }
    }

    public class Person
    {
        public string Name { get; set; } = default!;
        public int Age { get; set; }
    }
}
