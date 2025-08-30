using Improvements.Common.Interfaces;
using System;

namespace Improvements._65_DtosVsEntityExposure.Good
{
    // DTO hides sensitive/internal fields
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = "user@example.com";
    }

    public class GoodUseDto : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("=== GOOD: Using DTO ===");

            var dto = new UserDto { Id = 1, Email = "user@example.com" };
            Console.WriteLine($"API Response: {{ Id = {dto.Id}, Email = {dto.Email} }}");
            Console.WriteLine("Benefit: Only exposes safe fields, keeps domain model private.");
            Console.WriteLine();
        }
    }
}
