using System.Linq;
using Improvements.Common.Data;

namespace Improvements._09_FirstOrDefaultVsAny.Good
{
    public class ExistenceService
    {
        private readonly AppDbContext _context;
        public ExistenceService(AppDbContext context) => _context = context;

        // Best practice: use Any() for existence check
        public bool CheckUserExistsWithAny(string name)
        {
            return _context.Users
                .Any(u => u.Name == name);
        }
    }
}
