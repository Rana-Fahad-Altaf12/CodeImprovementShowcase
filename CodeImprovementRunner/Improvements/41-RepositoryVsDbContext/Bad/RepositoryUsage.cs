using Improvements.Common.Interfaces;
using System;
using System.Linq;

namespace Improvements._41_RepositoryVsDbContext.Bad
{
    public class RepositoryUsage : IImprovementDemo
    {
        public void Run()
        {
            using var context = new SchoolDbContext();

            var student = context.Students.FirstOrDefault(s => s.Id == 1);
            Console.WriteLine($"[Bad] Student Name: {student?.Name}");
        }
    }

    public class SchoolDbContext : IDisposable
    {
        public IQueryable<Student> Students => new[] {
            new Student { Id = 1, Name = "John Doe" }
        }.AsQueryable();

        public void Dispose() { }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
