using Improvements.Common.Interfaces;
using System;
using System.Text.Json;

namespace Improvements._81_SerializeObjectsVsDTOs.Bad
{
    public class SerializeEntireObjects : IImprovementDemo
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

            // Bad: serializing the entire object including sensitive data
            var json = JsonSerializer.Serialize(user);
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
}
