using Improvements.Common.Interfaces;
using System;
using System.Diagnostics;

namespace Improvements._72_UnitOfWorkImplementation.Bad
{
    public class DirectRepositoryUsage : IImprovementDemo
    {
        public void Run()
        {
            var sw = Stopwatch.StartNew();
            long memBefore = GC.GetTotalMemory(true);

            var repo1 = new StudentRepository();
            repo1.Add("Ali");

            var repo2 = new CourseRepository();
            repo2.Add("Math");

            // Imagine needing to rollback - no shared transaction context!
            Console.WriteLine("Changes committed separately, no Unit of Work.");

            long memAfter = GC.GetTotalMemory(false);
            sw.Stop();

            Console.WriteLine($"Time Taken: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine($"Memory Used: {memAfter - memBefore} bytes");
        }
    }

    // Fake repos
    public class StudentRepository
    {
        public void Add(string student) => Console.WriteLine($"Student added: {student}");
    }

    public class CourseRepository
    {
        public void Add(string course) => Console.WriteLine($"Course added: {course}");
    }
}
