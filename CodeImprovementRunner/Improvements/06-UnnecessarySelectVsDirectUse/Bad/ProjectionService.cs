using System.Collections.Generic;
using System.Linq;
using Improvements.Common.Data;

namespace Improvements._06_UnnecessarySelectVsDirectUse.Bad
{
    public class ProjectionService
    {
        private readonly AppDbContext _context;

        public ProjectionService(AppDbContext context)
        {
            _context = context;
        }

        public List<string> GetUsersWithAnonymousProjection()
        {
            return _context.Users
                .Select(x => new { x.Name }) // unnecessary anonymous type
                .Select(a => a.Name)
                .ToList();
        }
    }
}
