using Improvements.Common.Interfaces;
using System;
using System.Text.Json;

namespace Improvements._87_XmlVsJson.Good
{
    public class UseJsonWhenApplicable : IImprovementDemo
    {
        public void Run()
        {
            var obj = new Person { Name = "Fahad", Age = 30 };

            // Serialize using JSON
            string json = JsonSerializer.Serialize(obj);
            Console.WriteLine("JSON Output:");
            Console.WriteLine(json);

            // Deserialize back
            var deserializedObj = JsonSerializer.Deserialize<Person>(json);
            Console.WriteLine($"Deserialized Name: {deserializedObj.Name}");
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
