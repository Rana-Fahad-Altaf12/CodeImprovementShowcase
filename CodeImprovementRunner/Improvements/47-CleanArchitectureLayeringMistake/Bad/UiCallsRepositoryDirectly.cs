using Improvements.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Improvements._47_CleanArchitectureLayeringMistake.Bad
{
    public class UiCallsRepositoryDirectly : IImprovementDemo
    {
        public void Run()
        {
            var ui = new UserForm();
            ui.SaveUser("john@example.com");
        }

        public class UserRepository
        {
            public void Save(string email)
            {
                Console.WriteLine($"[Repository] Saving user {email} to DB");
            }
        }

        public class UserForm
        {
            private readonly UserRepository _repository = new();

            public void SaveUser(string email)
            {
                _repository.Save(email);
            }
        }
    }
}
