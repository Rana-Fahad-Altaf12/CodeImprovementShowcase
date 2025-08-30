using Improvements.Common.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace Improvements._54_NotUsingILogger.Good
{
    public class StructuredLogging : IImprovementDemo
    {
        private readonly ILogger<StructuredLogging> _logger;

        public StructuredLogging()
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            _logger = loggerFactory.CreateLogger<StructuredLogging>();
        }

        public void Run()
        {
            _logger.LogInformation("Starting application...");

            try
            {
                var result = Divide(10, 0);
                _logger.LogInformation("Result: {Result}", result);
            }
            catch (DivideByZeroException ex)
            {
                _logger.LogError(ex, "Attempted to divide by zero");
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Unexpected error occurred");
            }

            _logger.LogInformation("Application finished.");
        }

        private int Divide(int a, int b) => a / b;
    }
}
