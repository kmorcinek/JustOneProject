using System.Collections.Generic;
using System.Linq;

namespace JustOneProject.VariousStuff
{
    public class SynchronizationServiceMock
    {
        public IEnumerable<string> GetItemsFromFullSynchronization()
        {
            return Enumerable.Empty<string>();

            // Check current items
            // Download new and changed items
            // Make some diffs on data
            // etc
            return new[] {"ala", "ma", "kota"};
        }
    }
}