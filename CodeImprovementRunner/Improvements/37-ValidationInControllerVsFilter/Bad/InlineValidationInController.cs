using Improvements.Common.Interfaces;
namespace Improvements._37_ValidationInControllerVsFilter.Bad
{
    public class InlineValidationInController : IImprovementDemo
    {
        public class UserDto
        {
            public string Name { get; set; }
            public string Email { get; set; }
        }

        public class UserController
        {
            public string Register(UserDto user)
            {
                if (string.IsNullOrWhiteSpace(user.Name))
                    return "Name is required";

                if (!user.Email.Contains("@"))
                    return "Invalid email";

                return $"User {user.Name} registered successfully.";
            }
        }

        public void Run()
        {
            var controller = new UserController();
            var result = controller.Register(new UserDto { Name = "", Email = "test.com" });
            Console.WriteLine(result);
        }
    }
}
