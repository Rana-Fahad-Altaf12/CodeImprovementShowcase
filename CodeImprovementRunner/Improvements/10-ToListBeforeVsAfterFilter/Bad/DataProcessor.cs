using System.Collections.Generic;
using System.Linq;
using Improvements.Common.Models;

namespace Improvements._10_ToListBeforeVsAfterFilter.Bad
{
    public class DataProcessor
    {
        public List<User> FilterAfterToList(List<User> allUsers)
        {
            // Brings everything into memory before filtering
            return allUsers
                .ToList()
                .Where(x => x.Name == "Alice")
                .ToList();
        }
    }
}
