using Improvements.Common.Data;

namespace Improvements._08_CountVsAny.Good
{
    public class ExistenceCheckService
    {
        private readonly AppDbContext _context;
        public ExistenceCheckService(AppDbContext context) => _context = context;

        public bool CheckUsingAny()
        {
            return _context.Users
                .Any(u => u.Name == "Alice"); // Efficient
        }
    }
}
