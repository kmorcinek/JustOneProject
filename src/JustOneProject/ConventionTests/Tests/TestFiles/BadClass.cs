using System.Collections.Generic;

namespace JustOneProject.ConventionTests.Tests.TestFiles
{
    public struct BadClass
    {
        public BadClass(IEnumerable<int> ints)
        {
            Ints = ints;
        }

        public IEnumerable<int> Ints { get; }
    }
}