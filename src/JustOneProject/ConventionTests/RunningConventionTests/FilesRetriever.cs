using System.Collections.Generic;
using System.IO;

namespace JustOneProject.ConventionTests.RunningConventionTests
{
    class FilesRetriever
    {
        public static IEnumerable<string> GetFiles(string basePath)
        {
            // For easy using have it hardcoded
            return GetFiles(basePath, "*.cs");
        }

        static IEnumerable<string> GetFiles(string basePath, string searchPattern)
        {
            return Directory.EnumerateFiles(basePath, searchPattern, SearchOption.AllDirectories);
        }
    }
}