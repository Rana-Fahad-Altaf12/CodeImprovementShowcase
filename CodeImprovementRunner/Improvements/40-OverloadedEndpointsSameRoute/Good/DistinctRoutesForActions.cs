using Improvements.Common.Interfaces;
using Improvements.Common.MockAttributes;
namespace Improvements._40_OverloadedEndpointsSameRoute.Good
{
    public class DistinctRoutesForActions : IImprovementDemo
    {
        [Route("api/users")]
        public class UsersController
        {
            [HttpGet("by-id/{id}")]
            public string GetUserById([FromRoute] int id) => $"User with ID: {id}";

            [HttpGet("by-username/{username}")]
            public string GetUserByUsername([FromRoute] string username) => $"User with Username: {username}";
        }

        public void Run()
        {
            var controller = new UsersController();
            Console.WriteLine(controller.GetUserById(5));
            Console.WriteLine(controller.GetUserByUsername("fahad"));
        }
    }
}