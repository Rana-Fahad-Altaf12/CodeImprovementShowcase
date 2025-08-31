using Improvements.Common.Interfaces;
using System;
using System.Text.Json;

namespace Improvements._86_NewtonsoftVsSystemTextJson.Good
{
    public class UseSystemTextJsonConsistently : IImprovementDemo
    {
        public void Run()
        {
            var obj = new { Name = "Fahad", Age = 30 };

            // Serialize and Deserialize using System.Text.Json consistently
            string json = JsonSerializer.Serialize(obj);
            Console.WriteLine($"System.Text.Json JSON: {json}");

            var deserializedObj = JsonSerializer.Deserialize<dynamic>(json);
            Console.WriteLine($"Deserialized Name: {deserializedObj.Name}");
        }
    }
}
