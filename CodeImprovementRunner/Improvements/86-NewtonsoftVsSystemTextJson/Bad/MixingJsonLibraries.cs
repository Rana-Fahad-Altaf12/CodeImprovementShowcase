using Improvements.Common.Interfaces;
using Newtonsoft.Json; // Mixing libraries
using System;
using System.Text.Json;

namespace Improvements._86_NewtonsoftVsSystemTextJson.Bad
{
    public class MixingJsonLibraries : IImprovementDemo
    {
        public void Run()
        {
            var obj = new { Name = "Fahad", Age = 30 };

            // Serializing with Newtonsoft.Json
            string newtonsoftJson = JsonConvert.SerializeObject(obj);
            Console.WriteLine($"Newtonsoft JSON: {newtonsoftJson}");

            // Deserializing with System.Text.Json
            var deserializedObj = System.Text.Json.JsonSerializer.Deserialize<dynamic>(newtonsoftJson);
            Console.WriteLine($"Deserialized Name: {deserializedObj.Name}");
        }
    }
}
