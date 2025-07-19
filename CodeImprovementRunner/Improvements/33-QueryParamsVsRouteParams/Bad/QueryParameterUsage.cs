using Improvements.Common.Interfaces;
using Improvements.Common.MockAttributes;

namespace Improvements._33_QueryParamsVsRouteParams.Bad
{
    public class QueryParameterUsage : IImprovementDemo
    {
        [Route("api/users")]
        public class UsersController
        {
            [HttpGet]
            public string GetUser([FromQuery] int id)
            {
                return $"Fetching user with ID: {id}";
            }
        }

        public void Run()
        {
            var controller = new UsersController();
            Console.WriteLine(controller.GetUser(101));
        }
    }
}
