using System.Linq;
using Improvements.Common.Data;

namespace Improvements._09_FirstOrDefaultVsAny.Bad
{
    public class ExistenceService
    {
        private readonly AppDbContext _context;
        public ExistenceService(AppDbContext context) => _context = context;

        // Inefficient for just checking existence — fetches whole entity
        public bool CheckUserExistsWithFirstOrDefault(string name)
        {
            return _context.Users
                .Where(u => u.Name == name)
                .FirstOrDefault() != null;
        }
    }
}
