using Improvements.Common.Interfaces;
using System;

namespace Improvements._46_FatVsThinControllers.Good
{
    public class ThinControllerWithService : IImprovementDemo
    {
        public void Run()
        {
            var controller = new UserController(new UserRegistrationService());
            controller.Register("john@example.com");
        }

        public class UserController
        {
            private readonly UserRegistrationService _service;

            public UserController(UserRegistrationService service)
            {
                _service = service;
            }

            public void Register(string email)
            {
                _service.Register(email);
            }
        }

        public class UserRegistrationService
        {
            public void Register(string email)
            {
                if (!email.Contains("@"))
                {
                    Console.WriteLine("Invalid email.");
                    return;
                }

                Console.WriteLine($"Saving user {email} to database...");
                Console.WriteLine($"Sending welcome email to {email}...");
            }
        }
    }
}
