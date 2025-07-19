using Improvements.Common.Interfaces;
namespace Improvements._38_VersioningViaUrlVsHeader.Bad
{
    public class UrlVersioningExample : IImprovementDemo
    {
        public class HeaderApi
        {
            public string GetResponse(Dictionary<string, string> headers)
            {
                if (headers.TryGetValue("X-API-Version", out var version))
                {
                    if (version == "1.0")
                        return "Response from API v1.0";
                    if (version == "2.0")
                        return "Response from API v2.0";
                }
                return "Unknown or missing version";
            }
        }

        public void Run()
        {
            var api = new HeaderApi();
            var result = api.GetResponse(new Dictionary<string, string> { { "X-API-Version", "2.0" } });
            Console.WriteLine(result);
        }
    }
}