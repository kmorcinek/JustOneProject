using System.Collections.Generic;

namespace JustOneProject.VariousStuff
{
    public class SynchronizationServiceMock
    {
        public IEnumerable<string> GetItemsFromFullSynchronization()
        {
            // Check current items
            // Download new and changed items
            // Make some diffs on data
            // etc
            return new[] {"ala", "ma", "kota"};
        }
    }
}