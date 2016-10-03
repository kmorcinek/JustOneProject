using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace JustOneProject.TsImportsGenerator.Tests.Integration
{
    public class ManagerTests : IDisposable
    {
        const string BasePath = @"ManagerTest";

        public ManagerTests()
        {
            Directory.CreateDirectory(BasePath);
        }

        //[Fact]
        //public void Test()
        //{
        //    var ints = new[] {1, 2, 4, };

        //    var firstOrDefault = ints.GroupBy(n => n,
        //            (key, values) => new {Notice = key, Count = values.Count()}).Where(x => x.Count > 1)
        //        .FirstOrDefault();

        //    firstOrDefault.
        //}

        [Fact]
        public void Check_one_folder_with_two_enums()
        {
            const string heroFile = "MyCustomService.ts";

            string innerFolder = Path.Combine(BasePath, "models");
            Directory.CreateDirectory(innerFolder);

            RecreateFile(heroFile, @"    export class MyCustomService {

        constructor(
            private fileType: FileType,
            private fileType: FileType,
            private designStatus: DesignStatus 
        ) {
        }");

            TsImportsGeneratorRunner.Run(BasePath);

            string[] allLines = File.ReadAllLines(Path.Combine(BasePath, heroFile));

            allLines.First().Should().Be(@"import { FileType, DesignStatus } from ""./Enums"";");
            allLines.Skip(1).First().Should().Be(@"    export class MyCustomService {");
        }

        [Fact]
        public void Check_one_folder_with_interfaces_from_TypeLite()
        {
            const string heroFile = "MyCustomService.ts";

            string innerFolder = Path.Combine(BasePath, "models");
            Directory.CreateDirectory(innerFolder);

            RecreateFile(heroFile, @"    export class MyCustomService {

        constructor(
            private articleViewModel: IArticleViewModel 
        ) {
        }");

            TsImportsGeneratorRunner.Run(BasePath);

            string[] allLines = File.ReadAllLines(Path.Combine(BasePath, heroFile));

            allLines.First().Should().Be(@"import { IArticleViewModel } from ""./TypeLite.Net4"";");
        }

        [Fact]
        public void Check_one_folder()
        {
            const string heroFile = "MyCustomService.ts";

            string innerFolder = Path.Combine(BasePath, "models");
            Directory.CreateDirectory(innerFolder);

            RecreateFile(heroFile, @"    export class MyCustomService {

        constructor(
            private articleLinkViewModel: ArticleLinkViewModel
        ) {
        }");

            RecreateFile("models/ArticleLinkViewModel.ts", @"export class ArticleLinkViewModel implements IArticleLinkViewModel {}");

            TsImportsGeneratorRunner.Run(BasePath);

            string[] allLines = File.ReadAllLines(Path.Combine(BasePath, heroFile));

            allLines.First().Should().Be(@"import { ArticleLinkViewModel } from ""./models/ArticleLinkViewModel"";");
        }

        static void RecreateFile(string fileName, string content)
        {
            var path = Path.Combine(BasePath, fileName);

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            File.WriteAllText(path, content);
        }

        public void Dispose()
        {
            Directory.Delete(BasePath, true);
        }
    }
}