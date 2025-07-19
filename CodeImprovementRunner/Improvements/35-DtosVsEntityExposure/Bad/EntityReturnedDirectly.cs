using Improvements.Common.Interfaces;
namespace Improvements._35_DtosVsEntityExposure.Bad
{
    public class EntityReturnedDirectly : IImprovementDemo
    {
        public class User
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string PasswordHash { get; set; } // Sensitive!
            public string Role { get; set; }
        }

        public class UserController
        {
            public User GetUser()
            {
                return new User
                {
                    Id = 1,
                    Username = "admin",
                    PasswordHash = "hashed123",
                    Role = "Administrator"
                };
            }
        }

        public void Run()
        {
            var controller = new UserController();
            var result = controller.GetUser();
            Console.WriteLine($"Returned User: {result.Username}, PasswordHash: {result.PasswordHash}");
        }
    }
}
