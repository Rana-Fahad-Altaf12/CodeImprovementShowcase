using Improvements.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Improvements._84_AccessConfigDirectlyInDeepLayers.Bad
{
    public class DirectConfigAccess : IImprovementDemo
    {
        public void Run()
        {
            // Bad: deep layer directly accesses configuration
            Console.WriteLine("This is a bad way:\n\nvar config = new ConfigurationBuilder()" +
                "\n.SetBasePath(Directory.GetCurrentDirectory())\n.AddJsonFile(\"appsettings.json\")" +
                "\n.Build();\nstring apiKey = config[\"ApiSettings:ApiKey\"]!;" +
                "\nConsole.WriteLine($\"API Key in deep layer: {apiKey}\");");
            
                
                
                

            
            
        }
    }
}
