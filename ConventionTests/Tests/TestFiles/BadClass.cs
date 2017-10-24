using System.Collections.Generic;

namespace JustOneProject.ConventionTests.Tests.TestFiles
{
    public class BadClass
    {
        public BadClass(IEnumerable<int> ints)
        {
            Ints = ints;
        }

        public IEnumerable<int> Ints { get; }
    }
}