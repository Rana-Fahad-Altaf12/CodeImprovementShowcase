using Improvements.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Improvements._71_RepositoryVsDirectDbContext.Bad
{
    public class DirectDbContextUsage : IImprovementDemo
    {
        public void Run()
        {
            Console.WriteLine("=== BAD: Service depends directly on data context ===");

            var context = new FakeDbContext();
            var service = new StudentService(context);

            service.AddStudent("Ali");
            service.AddStudent("Sara");

            var students = service.GetStudents();
            foreach (var s in students)
            {
                Console.WriteLine($"Student: {s.Name}");
            }

            Console.WriteLine("Problem: Business logic is tightly coupled to data access (context).");
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

        // Service directly tied to the context
        public class StudentService
        {
            private readonly FakeDbContext _context;
            public StudentService(FakeDbContext context) => _context = context;

            public IEnumerable<Student> GetStudents() => _context.Students.ToList();

            public void AddStudent(string name)
            {
                _context.Add(new Student { Name = name });
                _context.SaveChanges();
            }
        }
    }
}
