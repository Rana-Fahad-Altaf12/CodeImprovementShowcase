using Improvements.Common.Interfaces;
using Improvements.Common.MockAttributes;
namespace Improvements._33_QueryParamsVsRouteParams.Good
{
    public class RouteParameterUsage : IImprovementDemo
    {
        public void Run()
        {
            var controller = new UsersController();
            Console.WriteLine(controller.GetUser(101));
        }


        [Route("api/users")]
        public class UsersController
        {
            [HttpGet("{id}")]
            public string GetUser([FromRoute] int id)
            {
                return $"Fetching user with ID: {id}";
            }
        }
    }
}
