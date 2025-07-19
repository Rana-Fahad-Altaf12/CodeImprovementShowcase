using Improvements.Common.Interfaces;
using System;

namespace Improvements._41_RepositoryVsDbContext.Good
{
    public class RepositoryUsage : IImprovementDemo
    {
        public void Run()
        {
            IStudentRepository repository = new StudentRepository();
            var student = repository.GetById(1);
            Console.WriteLine($"[Good] Student Name: {student?.Name}");
        }
    }

    public interface IStudentRepository
    {
        Student GetById(int id);
    }

    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _context = new();

        public Student GetById(int id)
        {
            return _context.FindStudentById(id);
        }
    }

    public class SchoolDbContext
    {
        public Student FindStudentById(int id)
        {
            return new Student { Id = 1, Name = "John Doe" };
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
