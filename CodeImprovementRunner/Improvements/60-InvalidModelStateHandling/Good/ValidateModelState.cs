using Improvements.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Improvements._60_InvalidModelStateHandling.Good
{
    public class ValidateModelState : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Good: Validate model state before saving...");

            var model = new UserDto { Name = "", Age = -1 }; // invalid

            var errors = Validate(model);
            if (errors.Count > 0)
            {
                Console.WriteLine("Model is invalid:");
                foreach (var error in errors)
                    Console.WriteLine($" - {error}");
                return;
            }

            SaveUser(model);
            Console.WriteLine("Saved user successfully");
        }

        private List<string> Validate(UserDto dto)
        {
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(dto.Name))
                errors.Add("Name is required");
            if (dto.Age < 0)
                errors.Add("Age must be non-negative");

            return errors;
        }

        private void SaveUser(UserDto dto)
        {
            // Pretend to save
        }

        private class UserDto
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
