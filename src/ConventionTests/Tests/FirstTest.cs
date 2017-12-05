using System.IO;
using FluentAssertions;
using Xunit;

namespace JustOneProject.ConventionTests.Tests
{
    public class FirstTest
    {
        public const string ConventionTestFiles = "ConventionTests/Tests/TestFiles";

        [Fact]
        public void Test()
        {
            var path = Path.Combine(ConventionTestFiles, "BadClass.cs");
            var content = File.ReadAllText(path);

            new AllowOnlyReadOnlyCollectionInConstructors().IsViolation(content).Should().BeTrue();
        }
    }
}