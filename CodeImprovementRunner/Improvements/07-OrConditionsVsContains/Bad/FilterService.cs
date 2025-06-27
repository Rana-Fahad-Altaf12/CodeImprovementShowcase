using System.Collections.Generic;
using System.Linq;
using Improvements.Common.Data;

namespace Improvements._07_OrConditionsVsContains.Bad
{
    public class FilterService
    {
        private readonly AppDbContext _context;

        public FilterService(AppDbContext context) => _context = context;

        public List<string> FilterUsersUsingOrConditions()
        {
            return _context.Users
                .Where(u => u.Name == "Alice" || u.Name == "Bob" || u.Name == "Charlie")
                .Select(u => u.Name)
                .ToList();
        }
    }
}
