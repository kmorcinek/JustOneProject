using System.Collections.Generic;
using System.IO;
using System.Linq;
using JustOneProject.ConventionTests.Tests;
using Xunit;

namespace JustOneProject.ConventionTests.RunningConventionTests
{
    public class AllowOnlyReadOnlyCollectionInConstructorsTests
    {
        [Fact]
        public void Test()
        {
            IEnumerable<string> files = FilesRetriever.GetFiles(FirstTest.ConventionTestFiles);

            string[] classes = GetViolatingClasses(files).ToArray();

            Assert.False(classes.Any(), $"Classes violating {nameof(AllowOnlyReadOnlyCollectionInConstructors)}: '{string.Join(", ", classes)}'");
        }

        static IEnumerable<string> GetViolatingClasses(IEnumerable<string> files)
        {
            foreach (var pathToFile in files)
            {
                //Console.WriteLine(pathToFile);

                var content = File.ReadAllText(pathToFile);

                if (new AllowOnlyReadOnlyCollectionInConstructors().IsViolation(content))
                {
                    yield return AllowOnlyReadOnlyCollectionInConstructors.GetClassName(content);
                }
            }
        }
    }
}