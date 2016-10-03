using System.IO;
using FluentAssertions;
using Xunit;

namespace JustOneProject.TsImportsGenerator.Tests
{
    public class RelativePathCreatorTests
    {
        [Fact]
        public void GetDirectoryName_returns_path_of_many_directories()
        {
            var directoryName = Path.GetDirectoryName("konik/ala/kota.ts");
            directoryName.Should().Be(@"konik\ala");
        }

        [Theory]
        [InlineData("/alertService/")]
        [InlineData("alertService/")]
        [InlineData("alertService")]
        [InlineData("/alertService")]
        public void Should_ignore_slashes_in_source_folder(string sourceFolder)
        {
            CreateSut().GetImportPath(sourceFolder, "file").Should().Be("../file");
        }

        [Theory]
        [InlineData("/alertService")]
        [InlineData("alertService")]
        public void Should_ignore_slashes_in_destination_file(string destinationFile)
        {
            CreateSut().GetImportPath("", destinationFile).Should().Be("./alertService");
        }

        [Theory]
        [InlineData(@"\services\alertService")]
        [InlineData(@"services\alertService")]
        public void Should_convert_backslashes_to_slashes_in_destination_file(string destinationFile)
        {
            CreateSut().GetImportPath("", destinationFile).Should().Be("./services/alertService");
        }

        [Theory]
        [InlineData("", "tests")]
        [InlineData("utils", "utils/tests")]
        public void Should_return_dot_when_in_the_same_folder(string sourceFolder, string destinationFile)
        {
            CreateSut().GetImportPath(sourceFolder, destinationFile).Should().Be("./tests");
        }

        [Theory]
        [InlineData("/services/", "file", "../file")]
        [InlineData("/services/authentication", "file", "../../file")]
        public void Should_go_up_the_hierarchy(string sourceFolder, string destinationFile, string expected)
        {
            CreateSut().GetImportPath(sourceFolder, destinationFile).Should().Be(expected);
        }

        [Theory]
        [InlineData("", "features/file", "./features/file")]
        [InlineData("", "features/touch/file", "./features/touch/file")]
        public void Should_go_down_the_hierarchy_and_start_with_dot(string sourceFolder, string destinationFolder, string expected)
        {
            CreateSut().GetImportPath(sourceFolder, destinationFolder).Should().Be(expected);
        }

        [Theory]
        [InlineData("/tests/", "/services/authentication/file", "../services/authentication/file")]
        [InlineData("/tests/utils", "tests/features/services/file", "../features/services/file")]
        public void Test_all(string sourceFolder, string destinationFolder, string expected)
        {
            CreateSut().GetImportPath(sourceFolder, destinationFolder).Should().Be(expected);
        }

        static RelativePathCreator CreateSut()
        {
            return new RelativePathCreator();
        }
    }
}