using Improvements.Common.Interfaces;
namespace Improvements._32_HardcodedUrlsVsUrlHelper.Good
{
    public class UrlHelperExample : IImprovementDemo
    {
        public void Run()
        {
            var urlHelper = new FakeUrlHelper();
            var routeValues = new { userId = 42 };
            string url = urlHelper.Action("Profile", "Users", routeValues);

            Console.WriteLine($"Generated URL: {url}");
            // Imagine HttpClient calling this URL
        }

        // Simulates ASP.NET Core's IUrlHelper
        public class FakeUrlHelper
        {
            public string Action(string action, string controller, object routeValues)
            {
                dynamic values = routeValues;
                return $"https://example.com/api/{controller}/{values.userId}/{action}";
            }
        }
    }
}
