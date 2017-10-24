using System;
using System.Collections.Generic;
using System.IO;
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

            foreach (var pathToFile in files)
            {
                //Console.WriteLine(pathToFile);

                var content = File.ReadAllText(pathToFile);

                if (new AllowOnlyReadOnlyCollectionInConstructors().IsViolation(content))
                {
                }
            }
        }
    }
}