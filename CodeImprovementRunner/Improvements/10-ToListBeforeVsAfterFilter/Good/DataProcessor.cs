using System.Collections.Generic;
using System.Linq;
using Improvements.Common.Models;

namespace Improvements._10_ToListBeforeVsAfterFilter.Good
{
    public class DataProcessor
    {
        public List<User> FilterBeforeToList(List<User> allUsers)
        {
            // Apply filter before materializing to memory
            return allUsers
                .Where(x => x.Name == "Alice")
                .ToList();
        }
    }
}
