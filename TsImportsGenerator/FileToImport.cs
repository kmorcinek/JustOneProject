namespace JustOneProject.TsImportsGenerator
{
    public class FileToImport
    {
        public string ClassName { get; }
        public string RelativeDestinationFile { get; }

        public FileToImport(string className, string relativeDestinationFile)
        {
            ClassName = className;
            RelativeDestinationFile = relativeDestinationFile;
        }
    }
}