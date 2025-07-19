using Improvements.Common.Interfaces;
using System;

namespace Improvements._45_ViolatingSRPInServices.Bad
{
    public class FatServiceWithMultipleResponsibilities : IImprovementDemo
    {
        public void Run()
        {
            var service = new UserAccountService();
            service.RegisterUser("john@example.com");
        }

        public class UserAccountService
        {
            public void RegisterUser(string email)
            {
                if (!IsValidEmail(email))
                {
                    Console.WriteLine("Invalid email.");
                    return;
                }

                Console.WriteLine($"Saving user {email} to database...");
                Console.WriteLine($"Sending welcome email to {email}...");
            }

            private bool IsValidEmail(string email)
            {
                return email.Contains("@");
            }
        }
    }
}
