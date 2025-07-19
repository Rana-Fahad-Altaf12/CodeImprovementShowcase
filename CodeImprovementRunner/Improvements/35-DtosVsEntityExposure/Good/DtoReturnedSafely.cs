using Improvements.Common.Interfaces;
namespace Improvements._35_DtosVsEntityExposure.Good
{
    public class DtoReturnedSafely : IImprovementDemo
    {
        public class User
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string PasswordHash { get; set; }
            public string Role { get; set; }
        }

        public class UserDto
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Role { get; set; }
        }

        public class UserController
        {
            public UserDto GetUser()
            {
                var user = new User
                {
                    Id = 1,
                    Username = "admin",
                    PasswordHash = "hashed123",
                    Role = "Administrator"
                };

                return new UserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Role = user.Role
                };
            }
        }

        public void Run()
        {
            var controller = new UserController();
            var result = controller.GetUser();
            Console.WriteLine($"Returned DTO: {result.Username}, Role: {result.Role}");
        }
    }
}
