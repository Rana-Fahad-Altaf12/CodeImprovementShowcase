using Improvements.Common.Interfaces;
using System;
using System.Text.Json;

namespace Improvements._81_SerializeObjectsVsDTOs.Good
{
    public class UseDTOsForSerialization : IImprovementDemo
    {
        public void Run()
        {
            var user = new User
            {
                Id = 1,
                Name = "Alice",
                PasswordHash = "secret-hash",
                Email = "alice@example.com"
            };

            // Good: serialize only DTO without sensitive data
            var dto = new UserDto
            {
                Id = user.Id,
                Name = user.Name
            };

            var json = JsonSerializer.Serialize(dto);
            Console.WriteLine(json);
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string Email { get; set; } = "";
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }
}
