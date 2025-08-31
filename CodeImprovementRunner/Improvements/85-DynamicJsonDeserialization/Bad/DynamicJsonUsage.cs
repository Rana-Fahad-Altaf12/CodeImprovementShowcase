using Improvements.Common.Interfaces;
using System;
using System.Text.Json;

namespace Improvements._85_DynamicJsonDeserialization.Bad
{
    public class DynamicJsonUsage : IImprovementDemo
    {
        public void Run()
        {
            string json = "{\"Name\":\"Fahad\",\"Age\":30}";
            dynamic obj = JsonSerializer.Deserialize<dynamic>(json);
            Console.WriteLine($"Name: {obj.Name}, Age: {obj.Age}");
        }
    }
}
