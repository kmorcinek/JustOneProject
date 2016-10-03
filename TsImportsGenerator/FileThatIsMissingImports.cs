namespace JustOneProject.TsImportsGenerator
{
    public class FileThatIsMissingImports
    {
        public string FullPath { get; }
        public string RelativeSourceFolder { get; }
        public string ClassName { get; }

        public FileThatIsMissingImports(string fullPath, string relativeSourceFolder, string className)
        {
            FullPath = fullPath;
            RelativeSourceFolder = relativeSourceFolder;
            ClassName = className;
        }
    }
}