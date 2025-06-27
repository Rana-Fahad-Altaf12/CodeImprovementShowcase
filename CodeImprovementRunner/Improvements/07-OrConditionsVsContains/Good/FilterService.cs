using System.Collections.Generic;
using System.Linq;
using Improvements.Common.Data;

namespace Improvements._07_OrConditionsVsContains.Good
{
    public class FilterService
    {
        private readonly AppDbContext _context;

        public FilterService(AppDbContext context) => _context = context;

        public List<string> FilterUsersUsingContains()
        {
            var names = new[] { "Alice", "Bob", "Charlie" };

            return _context.Users
                .Where(u => names.Contains(u.Name))
                .Select(u => u.Name)
                .ToList();
        }
    }
}
