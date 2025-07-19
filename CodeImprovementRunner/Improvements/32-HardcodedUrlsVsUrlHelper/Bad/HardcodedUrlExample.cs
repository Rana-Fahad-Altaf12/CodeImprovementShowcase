using Improvements.Common.Interfaces;
namespace Improvements._32_HardcodedUrlsVsUrlHelper.Bad
{
    public class HardcodedUrlExample : IImprovementDemo
    {
        public void Run()
        {
            string baseUrl = "https://example.com";
            string hardcodedUrl = baseUrl + "/api/users/42/profile";

            Console.WriteLine($"Calling hardcoded URL: {hardcodedUrl}");
            // Imagine HttpClient calling this URL
        }
    }
}
