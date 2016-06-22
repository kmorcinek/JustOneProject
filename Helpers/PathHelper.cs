using System.IO;

namespace JustOneProject.Helpers
{
    public static class PathHelper
    {
        public static void EnsureDirectoryExists(string filePath)
        {
            var directoryPath = Path.GetDirectoryName(filePath);
            Directory.CreateDirectory(directoryPath);
        }
    }
}