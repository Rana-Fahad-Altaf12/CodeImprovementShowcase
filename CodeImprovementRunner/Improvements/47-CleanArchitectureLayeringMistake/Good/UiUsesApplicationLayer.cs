using Improvements.Common.Interfaces;
using System;

namespace Improvements._47_CleanArchitectureLayeringMistake.Good
{
    public class UiUsesApplicationLayer : IImprovementDemo
    {
        public void Run()
        {
            var ui = new UserForm(new UserService(new UserRepository()));
            ui.SaveUser("john@example.com");
        }

        public class UserRepository
        {
            public void Save(string email)
            {
                Console.WriteLine($"[Repository] Saving user {email} to DB");
            }
        }

        public class UserService
        {
            private readonly UserRepository _repository;

            public UserService(UserRepository repository)
            {
                _repository = repository;
            }

            public void Register(string email)
            {
                if (!email.Contains("@"))
                {
                    Console.WriteLine("Invalid email.");
                    return;
                }

                _repository.Save(email);
            }
        }

        public class UserForm
        {
            private readonly UserService _service;

            public UserForm(UserService service)
            {
                _service = service;
            }

            public void SaveUser(string email)
            {
                _service.Register(email);
            }
        }
    }
}
