using Improvements.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Improvements._83_ConfigInCodeVsAppSettings.Good
{
    public class UseAppSettings : IImprovementDemo
    {
        public void Run()
        {
            // Good: load configuration from appsettings.json
            /* var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: false)
                 .Build();

             string connectionString = config["Database:ConnectionString"]!;
             int retryCount = int.Parse(config["Database:RetryCount"]!);

             Console.WriteLine($"Connection: {connectionString}, RetryCount: {retryCount}");
             */
            Console.WriteLine($"Below is the good way!\n\nvar config = new ConfigurationBuilder()\n" +
                $".SetBasePath(Directory.GetCurrentDirectory())\n.AddJsonFile(\"appsettings.json\", optional: false)\n" +
                $".Build();\n\nstring connectionString = config[\"Database:ConnectionString\"]!;" +
                $"\nint retryCount = int.Parse(config[\"Database:RetryCount\"]!);");

        }
    }
}
