using Improvements.Common.Interfaces;
using System;

namespace Improvements._45_ViolatingSRPInServices.Good
{
    public class SplitResponsibilitiesIntoServices : IImprovementDemo
    {
        public void Run()
        {
            var emailValidator = new EmailValidator();
            var userRepository = new UserRepository();
            var emailService = new EmailService();
            var userService = new UserAccountService(emailValidator, userRepository, emailService);

            userService.RegisterUser("john@example.com");
        }

        public class UserAccountService
        {
            private readonly EmailValidator _emailValidator;
            private readonly UserRepository _userRepository;
            private readonly EmailService _emailService;

            public UserAccountService(
                EmailValidator emailValidator,
                UserRepository userRepository,
                EmailService emailService)
            {
                _emailValidator = emailValidator;
                _userRepository = userRepository;
                _emailService = emailService;
            }

            public void RegisterUser(string email)
            {
                if (!_emailValidator.IsValid(email))
                {
                    Console.WriteLine("Invalid email.");
                    return;
                }

                _userRepository.SaveUser(email);
                _emailService.SendWelcomeEmail(email);
            }
        }

        public class EmailValidator
        {
            public bool IsValid(string email) => email.Contains("@");
        }

        public class UserRepository
        {
            public void SaveUser(string email) => Console.WriteLine($"Saving user {email} to database...");
        }

        public class EmailService
        {
            public void SendWelcomeEmail(string email) => Console.WriteLine($"Sending welcome email to {email}...");
        }
    }
}
