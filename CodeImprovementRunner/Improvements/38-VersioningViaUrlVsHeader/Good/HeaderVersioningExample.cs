using Improvements.Common.Interfaces;
namespace Improvements._38_VersioningViaUrlVsHeader.Good
{
    public class HeaderVersioningExample : IImprovementDemo
    {
        public class UrlApi
        {
            public string GetResponse(string url)
            {
                if (url.StartsWith("/api/v1/"))
                    return "Response from API v1.0";
                if (url.StartsWith("/api/v2/"))
                    return "Response from API v2.0";

                return "Unknown version";
            }
        }

        public void Run()
        {
            var api = new UrlApi();
            var result = api.GetResponse("/api/v2/users");
            Console.WriteLine(result);
        }
    }
}