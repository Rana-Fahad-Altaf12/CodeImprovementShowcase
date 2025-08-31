using Improvements.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using System;

namespace Improvements._89_ConfigReloadWithoutIOptionsSnapshot.Bad
{
    public class ManualConfigReload : IImprovementDemo
    {
        public void Run()
        {
            // Load configuration manually
            Console.WriteLine("var builder = new ConfigurationBuilder().AddJsonFile(\"appsettings.json\", optional: true, reloadOnChange: true);" +
                "\nvar configuration = builder.Build();\nstring mySetting = configuration[\"MySetting\"];\n" +
                "Console.WriteLine($\"Initial value: {mySetting}\");\nconfiguration.Reload();" +
                "\nstring reloadedValue = configuration[\"MySetting\"];\nConsole.WriteLine($\"Reloaded value: {reloadedValue}\");");
        }
    }
}
