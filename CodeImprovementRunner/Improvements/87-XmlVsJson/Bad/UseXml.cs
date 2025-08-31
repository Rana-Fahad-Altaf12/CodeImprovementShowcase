using Improvements.Common.Interfaces;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Improvements._87_XmlVsJson.Bad
{
    public class UseXml : IImprovementDemo
    {
        public void Run()
        {
            var obj = new Person { Name = "Fahad", Age = 30 };

            // Serializing with XML
            var serializer = new XmlSerializer(typeof(Person));
            using var stringWriter = new StringWriter();
            serializer.Serialize(stringWriter, obj);
            string xml = stringWriter.ToString();

            Console.WriteLine("XML Output:");
            Console.WriteLine(xml);

            // Deserializing back
            using var reader = new StringReader(xml);
            var deserializedObj = (Person)serializer.Deserialize(reader);
            Console.WriteLine($"Deserialized Name: {deserializedObj.Name}");
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
