using Improvements.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using System;

namespace Improvements._84_AccessConfigDirectlyInDeepLayers.Good
{
    public class InjectConfigViaDI : IImprovementDemo
    {
        private readonly string _apiKey;

        public InjectConfigViaDI()
        {
            // In a real app, this would come via DI
            _apiKey = AppConfig.ApiKey;
        }

        public void Run()
        {
            Console.WriteLine($"API Key from injected config: {_apiKey}");
        }
    }

    // Simulate configuration injection
    public static class AppConfig
    {
        public static string ApiKey { get; } = "InjectedApiKey123";
    }
}
