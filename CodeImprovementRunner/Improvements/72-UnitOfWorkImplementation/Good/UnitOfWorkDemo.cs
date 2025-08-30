using Improvements.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Improvements._72_UnitOfWorkImplementation.Good
{
    public class UnitOfWorkDemo : IImprovementDemo
    {
        public void Run()
        {
            var sw = Stopwatch.StartNew();
            long memBefore = GC.GetTotalMemory(true);

            using (var uow = new UnitOfWork())
            {
                uow.Students.Add("Ali");
                uow.Courses.Add("Math");

                uow.Commit();
            }

            long memAfter = GC.GetTotalMemory(false);
            sw.Stop();

            Console.WriteLine("Changes committed together with Unit of Work.");
            Console.WriteLine($"Time Taken: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine($"Memory Used: {memAfter - memBefore} bytes");
        }
    }

    public class UnitOfWork : IDisposable
    {
        public StudentRepository Students { get; }
        public CourseRepository Courses { get; }
        private readonly List<Action> _pending = new();

        public UnitOfWork()
        {
            Students = new StudentRepository(_pending);
            Courses = new CourseRepository(_pending);
        }

        public void Commit()
        {
            foreach (var action in _pending) action();
            Console.WriteLine("All changes saved in one transaction.");
            _pending.Clear();
        }

        public void Dispose() => _pending.Clear();
    }

    public class StudentRepository
    {
        private readonly List<Action> _pending;
        public StudentRepository(List<Action> pending) => _pending = pending;
        public void Add(string student) => _pending.Add(() => Console.WriteLine($"Student added: {student}"));
    }

    public class CourseRepository
    {
        private readonly List<Action> _pending;
        public CourseRepository(List<Action> pending) => _pending = pending;
        public void Add(string course) => _pending.Add(() => Console.WriteLine($"Course added: {course}"));
    }
}
