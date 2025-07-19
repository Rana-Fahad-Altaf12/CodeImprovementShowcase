using Improvements.Common.Interfaces;
namespace Improvements._37_ValidationInControllerVsFilter.Good
{
    public class CentralizedValidationFilter : IImprovementDemo
    {
        public class UserDto
        {
            public string Name { get; set; }
            public string Email { get; set; }
        }

        public class ValidationFilter
        {
            public static bool Validate(UserDto user, out string error)
            {
                if (string.IsNullOrWhiteSpace(user.Name))
                {
                    error = "Name is required";
                    return false;
                }

                if (!user.Email.Contains("@"))
                {
                    error = "Invalid email";
                    return false;
                }

                error = null;
                return true;
            }
        }

        public class UserController
        {
            public string Register(UserDto user)
            {
                if (!ValidationFilter.Validate(user, out var error))
                    return error;

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
