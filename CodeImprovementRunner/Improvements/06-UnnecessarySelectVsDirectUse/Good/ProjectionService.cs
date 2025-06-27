using System.Collections.Generic;
using System.Linq;
using Improvements.Common.Data;

namespace Improvements._06_UnnecessarySelectVsDirectUse.Good
{
    public class ProjectionService
    {
        private readonly AppDbContext _context;

        public ProjectionService(AppDbContext context)
        {
            _context = context;
        }

        public List<string> GetUsersDirectly()
        {
            return _context.Users
                .Select(x => x.Name)
                .ToList();
        }
    }
}
