using Improvements.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Improvements._60_InvalidModelStateHandling.Bad
{
    public class IgnoringModelState : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("Bad: Ignoring model state...");

            var model = new UserDto { Name = "", Age = -1 }; // invalid

            // No validation check
            SaveUser(model);

            Console.WriteLine("Saved user (but data is invalid!)");
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
