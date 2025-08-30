using Improvements.Common.Interfaces;
using System;

namespace Improvements._65_DtosVsEntityExposure.Bad
{
    // Simulated EF entity
    public class UserEntity
    {
        public int Id { get; set; }
        public string PasswordHash { get; set; } = "SECRET_HASH";
        public string Email { get; set; } = "user@example.com";
    }

    public class BadExposeEntity : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("=== BAD: Exposing Entity directly ===");

            var entity = new UserEntity();
            Console.WriteLine($"API Response: {{ Id = {entity.Id}, PasswordHash = {entity.PasswordHash}, Email = {entity.Email} }}");
            Console.WriteLine("Problem: Exposes internal fields like PasswordHash, leaks implementation details.");
            Console.WriteLine();
        }
    }
}
