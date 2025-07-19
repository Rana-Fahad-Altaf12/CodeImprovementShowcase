using Improvements.Common.Interfaces;
using System;

namespace Improvements._46_FatVsThinControllers.Bad
{
    public class FatController : IImprovementDemo
    {
        public void Run()
        {
            var controller = new UserController();
            controller.Register("john@example.com");
        }

        public class UserController
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
