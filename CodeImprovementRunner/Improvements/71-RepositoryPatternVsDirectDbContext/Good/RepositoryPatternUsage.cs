using Improvements.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Improvements._71_RepositoryVsDirectDbContext.Good
{
    public class RepositoryPatternUsage : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("=== GOOD: Service depends on repository abstraction ===");

            var context = new FakeDbContext();
            IStudentRepository repo = new StudentRepository(context);
            var service = new StudentService(repo);

            service.AddStudent("Ali");
            service.AddStudent("Sara");

            var students = service.GetStudents();
            foreach (var s in students)
            {
                Console.WriteLine($"Student: {s.Name}");
            }

            Console.WriteLine("Benefit: Business logic depends on an abstraction, not the data access detail.");
            Console.WriteLine();
        }

        // Simulated entity
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
        }

        // Simulated DbContext (no EF dependency; console-friendly)
        public class FakeDbContext
        {
            private int _nextId = 1;
            public List<Student> Students { get; } = new List<Student>();

            public void Add(Student s)
            {
                s.Id = _nextId++;
                Students.Add(s);
            }

            public void SaveChanges()
            {
                // no-op in this fake context
            }
        }

        // Repository abstraction
        public interface IStudentRepository
        {
            IEnumerable<Student> GetAll();
            void Add(Student student);
        }

        // Repository implementation encapsulates data access
        public class StudentRepository : IStudentRepository
        {
            private readonly FakeDbContext _context;
            public StudentRepository(FakeDbContext context) => _context = context;

            public IEnumerable<Student> GetAll() => _context.Students.ToList();

            public void Add(Student student)
            {
                _context.Add(student);
                _context.SaveChanges();
            }
        }

        // Service depends on abstraction (easy to unit-test with a mock)
        public class StudentService
        {
            private readonly IStudentRepository _repository;
            public StudentService(IStudentRepository repository) => _repository = repository;

            public IEnumerable<Student> GetStudents() => _repository.GetAll();

            public void AddStudent(string name) => _repository.Add(new Student { Name = name });
        }
    }
}
