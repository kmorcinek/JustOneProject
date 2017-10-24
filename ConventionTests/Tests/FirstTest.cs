using System.IO;
using FluentAssertions;
using Xunit;

namespace JustOneProject.ConventionTests.Tests
{
    public class FirstTest
    {
        [Fact]
        public void Test()
        {
            var path = Path.Combine("ConventionTests/Tests/TestFiles", "BadClass.cs");
            var content = File.ReadAllText(path);

            new AllowOnlyReadOnlyCollectionInConstructors().IsViolation(content).Should().BeTrue();
        }
    }
}