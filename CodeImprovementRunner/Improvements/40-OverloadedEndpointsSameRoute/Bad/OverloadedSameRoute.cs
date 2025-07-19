using Improvements.Common.Interfaces;
using Improvements.Common.MockAttributes;
namespace Improvements._40_OverloadedEndpointsSameRoute.Bad
{
    public class OverloadedSameRoute : IImprovementDemo
    {
        [Route("api/users")]
        public class UsersController
        {
            // Ambiguous: same route with different parameter sets
            [HttpGet]
            public string GetUser(int id) => $"User with ID: {id}";

            [HttpGet]
            public string GetUser(string username) => $"User with Username: {username}";
        }

        public void Run()
        {
            var controller = new UsersController();
            Console.WriteLine(controller.GetUser(5));
            Console.WriteLine(controller.GetUser("fahad"));
        }
    }
}