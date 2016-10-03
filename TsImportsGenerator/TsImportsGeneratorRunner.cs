using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JustOneProject.TsImportsGenerator
{
    public class TsImportsGeneratorRunner
    {
        public static void Run(string basePath)
        {
            basePath = Path.GetFullPath(basePath);

            var files = Directory.EnumerateFiles(basePath, "*.ts", SearchOption.AllDirectories).ToArray();

            var filesThatAreMissingImports = FilesThatAreMissingImports(basePath, files);
            var allDefinitions = GetAllDefinitions(basePath, files);

            allDefinitions.AddRange(GetEnumDefinitions());
            allDefinitions.AddRange(GetInterfacesDefinitions());

            CheckForDuplicates(allDefinitions);

            foreach (var item in filesThatAreMissingImports
                //.Where(x =>
                //new[]
                //{
                //    //"ArticleLinkViewModel",
                //    "MyCustomService",
                //    "ArticleViewModel"
                //}.Contains(x.ClassName))
                )
            {
                Do(item, allDefinitions);
            }
        }

        static List<FileThatIsMissingImports> FilesThatAreMissingImports(string basePath, IEnumerable<string> files)
        {
            var filesThatAreMissingImports = new List<FileThatIsMissingImports>();

            var filesToIgnore = new[]
            {
                "TypeLite.Net4.d.ts",
                "Enums.ts",
                "formatToFixedLength.ts",
                "register.ts",
                "resolveReferences.ts",
                "TestsRunner.ts"
            };

            foreach (var filePath in files)
            {
                Console.WriteLine(filePath);

                string fileName = Path.GetFileName(filePath);

                if (filePath.Contains("directives"))
                {
                    continue;
                }

                if (filesToIgnore.Contains(fileName))
                {
                    continue;
                }

                var content = File.ReadAllText(filePath);

                string className = "app";
                try
                {
                    className = RetrieveClassName.GetClassName(content);
                }
                catch (Exception ex)
                {
                    var message = ex.Message + Environment.NewLine + $"File: {filePath}";
                    Console.WriteLine(message);
                    //throw new Exception(message);
                }

                var classWithPath = new FileThatIsMissingImports(
                    filePath,
                    Path.GetDirectoryName(filePath.Replace(basePath, string.Empty)),
                    className);

                filesThatAreMissingImports.Add(classWithPath);
            }

            return filesThatAreMissingImports;
        }

        static List<FileToImport> GetAllDefinitions(string basePath, IEnumerable<string> files)
        {
            var allDefinitions = new List<FileToImport>();

            var filesToIgnore = new[]
            {
                "app.ts",
                "TypeLite.Net4.d.ts",
                "Enums.ts",
                "global.d.ts",
                "formatToFixedLength.ts",
                "register.ts",
                "resolveReferences.ts",
                "TestsRunner.ts"
            };

            foreach (var filePath in files)
            {
                Console.WriteLine(filePath);

                string fileName = Path.GetFileName(filePath);

                if (filePath.Contains("directives"))
                {
                    continue;
                }

                if (filesToIgnore.Contains(fileName))
                {
                    continue;
                }

                var content = File.ReadAllText(filePath);

                try
                {
                    var className = RetrieveClassName.GetClassName(content);

                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);

                    var fileToImport = new FileToImport(
                        className,
                        Path.Combine(Path.GetDirectoryName(filePath.Replace(basePath, string.Empty)),
                            fileNameWithoutExtension));

                    allDefinitions.Add(fileToImport);
                }
                catch (Exception ex)
                {
                    var message = ex.Message + Environment.NewLine + $"File: {filePath}";
                    Console.WriteLine(message);
                    throw new Exception(message);
                }
            }

            return allDefinitions;
        }

        static void CheckForDuplicates(List<FileToImport> allDefinitions)
        {
            try
            {
                var singleOrDefault = allDefinitions.SingleOrDefault(x => x.ClassName == "GetComponentsQuery");
            }
            catch (Exception)
            {
                foreach (var file in allDefinitions.Where(x => x.ClassName == "GetComponentsQuery"))
                {
                    Console.WriteLine(file.ClassName);
                    Console.WriteLine(file.RelativeDestinationFile);
                }

                throw;
            }
        }

        static FileToImport[] GetEnumDefinitions()
        {
            var names = new[] {
                "FileType", "DesignStatus", "UnitOfMeasure", "StrategyOfPartId", "DrawingType", "MeasuringSystem",
                "ArticleType", "Shape", "RoleType"
            };

            var classWithPaths = names.Select(x => new FileToImport(
                x,
                "Enums"));

            return classWithPaths.ToArray();
        }

        static FileToImport[] GetInterfacesDefinitions()
        {
            var names = new[] {
                "GetComponentsQuery", "ThinComponentViewModel", "Guid", "ArticleEditModel", "ArticleListViewModel", "CompanyViewModel",
                "DesignViewModel", "DrawingDimensionViewModel", "EditMaterialViewModel", "IArticleLinkViewModel", "IArticleViewModel", "IComponentViewModel",
                "MaterialListViewModel", "MaterialViewModel", "PropertyViewModel", "ResourceViewModel", "ShapeWithDimensionsViewModel", "SynchronizationLogViewModel",
                "UserListViewModel", "UserViewModel", "DrawingDimensionBase", "ArticleSelectionViewModel", "MaterialSelectionViewModel", "DataTablesSelectItem",
                "ICurrentUserViewModel", "UserSelectionViewModel", "CanDeleteArticleQuery", "SaveDesignCommand", "GenerateCategoryUsingPrefixQuery", "GeneratePartIdQuery",
                "NextGsubNumberQuery", "OpenInCreoWebCommand", "ClearSynchronizationLogsCommand", "GetSynchronizationLogsRecursivelyQuery", "GetSynchronizationLogsQuery",
                "OpenFileInWindowsClientCommand"
            };

            var classWithPaths = names.Distinct().Select(x => new FileToImport(
                x,
                "TypeLite.Net4.ts"));

            return classWithPaths.ToArray();
        }

        static void Do(FileThatIsMissingImports item, List<FileToImport> allDefinitions)
        {
            Console.WriteLine($"{nameof(allDefinitions)}.Count = {allDefinitions.Count}");

            var classesToImport = new List<FileToImport>();

            string[] identifiers = IdentifiersParser.GetWords(File.ReadAllText(item.FullPath));

            foreach (var identifier in identifiers)
            {
                // Do not add class itself (the identifier is always on the top
                if (identifier == item.ClassName)
                {
                    continue;
                }

                var matchingDefinitions = allDefinitions.Where(x => x.ClassName == identifier);

                var moreThanOne = matchingDefinitions.GroupBy(n => n,
                                        (key, values) => new { NameOfClass = key, Count = values.Count() })
                                        .Where(x => x.Count > 1)
                                        .FirstOrDefault();

                if (moreThanOne != null)
                {
                    throw new InvalidOperationException($"{nameof(moreThanOne)} = {moreThanOne.NameOfClass}");
                }

                try
                {
                    var classToAdd = allDefinitions.SingleOrDefault(x => x.ClassName == identifier);

                    if (classToAdd != null)
                    {
                        classesToImport.Add(classToAdd);
                    }
                }
                catch (Exception)
                {
                    var classNames = allDefinitions.Select(x => x.ClassName).ToList();
                    classNames.Sort();

                    foreach (var className in classNames)
                    {
                        Console.WriteLine(className);
                    }

                    throw new InvalidOperationException(identifier + " is duplicated");
                }
            }

            AddImports(item, classesToImport);
        }

        static void AddImports(FileThatIsMissingImports item, List<FileToImport> classesToImport)
        {
            var content = File.ReadAllText(item.FullPath);

            var dictionary = new Dictionary<string, List<string>>();

            foreach (var toImport in classesToImport)
            {
                //var destinationFile = Path.Combine(toImport.RelativePath, toImport.FileName);
                var importPath = new RelativePathCreator().GetImportPath(item.RelativeSourceFolder, toImport.RelativeDestinationFile);

                Console.WriteLine($"{nameof(importPath)} = {importPath}");

                if (dictionary.ContainsKey(importPath) == false)
                {
                    dictionary[importPath] = new List<string>();
                }

                dictionary[importPath].Add(toImport.ClassName);
            }

            foreach (KeyValuePair<string, List<string>> keyValuePair in dictionary)
            {
                var importString = new AddImports().CreateImportString(keyValuePair.Key, keyValuePair.Value);

                Console.WriteLine($"{nameof(importString)} = {importString}");

                content = importString + Environment.NewLine + content;
            }

            File.WriteAllText(item.FullPath, content);
        }
    }
}