using Improvements.Common.Interfaces;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Improvements._88_BinaryFormatterUsage.Bad
{
    [Serializable]
    public class BinaryFormatter : IImprovementDemo
    {
        public void Run()
        {
            var obj = new Person { Name = "Fahad", Age = 30 };
            /*
            // Serializing using BinaryFormatter (unsafe)
            var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using var ms = new MemoryStream();
#pragma warning disable SYSLIB0011
            formatter.Serialize(ms, obj);
#pragma warning restore SYSLIB0011

            Console.WriteLine($"Serialized {ms.Length} bytes using BinaryFormatter");

            // Deserializing
            ms.Position = 0;
#pragma warning disable SYSLIB0011
            var deserialized = (Person)formatter.Deserialize(ms);
#pragma warning restore SYSLIB0011
            */
            Console.WriteLine($"BinaryFormatter is obselete");
        }
    }

    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
