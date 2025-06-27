using Improvements.Common.Models;

namespace Improvements.Common.Data
{
    public class UserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context) => _context = context;

        public void Add(User user) => _context.Users.Add(user);
        public void AddRange(IEnumerable<User> users) => _context.Users.AddRange(users);

        public void Save() => _context.SaveChanges();

        public int Count() => _context.Users.Count();

        public List<User> All() => _context.Users.ToList();

        public IQueryable<User> Query() => _context.Users.AsQueryable();
    }
}