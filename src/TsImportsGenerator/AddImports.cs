using System.Collections.Generic;
using System.IO;

namespace JustOneProject.TsImportsGenerator
{
    public class AddImports
    {
        public string CreateImportString(string relativePathToFile, IEnumerable<string> classes)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(relativePathToFile);

            var goodPath = Path.Combine(Path.GetDirectoryName(relativePathToFile), fileNameWithoutExtension)
                .Replace('\\', '/');

            string allClasses = string.Join(", ", classes);

            return $@"import {{ {allClasses} }} from ""{goodPath}"";";
        }
    }
}