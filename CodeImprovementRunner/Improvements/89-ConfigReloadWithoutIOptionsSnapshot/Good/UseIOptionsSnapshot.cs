using Improvements.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace Improvements._89_ConfigReloadWithoutIOptionsSnapshot.Good
{
    public class UseIOptionsSnapshotDemo : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("var services = new ServiceCollection();\nservices.AddOptions<MySettings>()" +
                ".Configure<IConfiguration>((settings, config) =>\n{\nconfig.GetSection(\"MySettings\").Bind(settings);\n});" +
                "var configuration = new ConfigurationBuilder().AddJsonFile(\"appsettings.json\", optional: true, reloadOnChange: true)\n" +
                ".Build();\nservices.Configure<MySettings>(configuration.GetSection(\"MySettings\"));" +
                "\nvar provider = services.BuildServiceProvider();" +
                "\nvar optionsSnapshot = provider.GetRequiredService<IOptionsSnapshot<MySettings>>();\n" +
                "Console.WriteLine($\"Current value: {optionsSnapshot.Value.SomeSetting}\");");
        }
    }

    public class MySettings
    {
        public string SomeSetting { get; set; }
    }
}
