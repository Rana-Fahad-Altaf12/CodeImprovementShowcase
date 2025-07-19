using Improvements.Common.Interfaces;
namespace Improvements._39_IActionResultVsGenericTypes.Bad
{
    public class UsesGenericReturn : IImprovementDemo
    {
        public class UserController
        {
            // Returning raw type directly
            public string GetUserName(int id)
            {
                if (id <= 0) return null;
                return $"User-{id}";
            }
        }

        public void Run()
        {
            var controller = new UserController();
            var user = controller.GetUserName(5);
            Console.WriteLine(user ?? "User not found");
        }
    }
}