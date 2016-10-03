using FluentAssertions;
using Xunit;

namespace JustOneProject.TsImportsGenerator.Tests
{
    public class AddImportsTests
    {
        [Fact]
        public void Test()
        {
            string result = CreateSut().CreateImportString("./services/ArticleService.ts", new[] { "ArticleService" });

            result.Should().Be(@"import { ArticleService } from ""./services/ArticleService"";");
        }

        [Fact]
        public void Should_work_for_many_exports_from_file()
        {
            string result = CreateSut().CreateImportString("./services/ArticleService.ts", new[] { "ArticleService", "GuidService" });

            result.Should().Be(@"import { ArticleService, GuidService } from ""./services/ArticleService"";");
        }

        static AddImports CreateSut()
        {
            return new AddImports();
        }
    }
}