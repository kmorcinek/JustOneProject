using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace JustOneProject.Extensions.Tests
{
    public class CollectionExtensionsTests
    {
        private readonly int[] _numbers = { 1, 3, 5 };
        private readonly Func<int, bool> _predicate = x => x > 2;

        [Fact]
        public void TestList()
        {
            ICollection<int> list = new List<int>(_numbers);

            list.RemoveAll(_predicate);

            Assert.Equal(1, list.Count);
            Assert.Equal(1, list.First());
        }

        [Fact]
        public void TestNotList()
        {
            ICollection<int> linkedList = new LinkedList<int>(_numbers);

            linkedList.RemoveAll(_predicate);

            Assert.Equal(1, linkedList.Count);
            Assert.Equal(1, linkedList.First());
        }
    }
}