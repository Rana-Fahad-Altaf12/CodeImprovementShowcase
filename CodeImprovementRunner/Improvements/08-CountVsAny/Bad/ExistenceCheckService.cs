using Improvements.Common.Data;

namespace Improvements._08_CountVsAny.Bad
{
    public class ExistenceCheckService
    {
        private readonly AppDbContext _context;
        public ExistenceCheckService(AppDbContext context) => _context = context;

        public bool CheckUsingCount()
        {
            return _context.Users
                .Where(u => u.Name == "Alice")
                .Count() > 0; // Inefficient
        }
    }
}
