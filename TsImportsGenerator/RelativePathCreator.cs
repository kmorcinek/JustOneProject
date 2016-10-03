using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JustOneProject.TsImportsGenerator
{
    public class RelativePathCreator
    {
        public string GetImportPath(string sourceFolder, string destinationFile)
        {
            string fileName = Path.GetFileName(destinationFile);
            string destinationFolder = Path.GetDirectoryName(destinationFile);

            List<string> sourceFolders = SplitToFolders(sourceFolder).ToList();
            List<string> destinationFolders = SplitToFolders(destinationFolder).ToList();

            if (sourceFolders.SequenceEqual(destinationFolders))
            {
                return "./" + fileName;
            }

            List<string> foldersList = new List<string>();

            int i = 0;
            while (i < sourceFolders.Count && i < destinationFolders.Count)
            {
                if (sourceFolders[i] == destinationFolders[i])
                {
                    sourceFolders.RemoveAt(i);
                    destinationFolders.RemoveAt(i);
                }

                i++;
            }

            foreach (var _ in sourceFolders)
            {
                foldersList.Add("..");
            }

            if (foldersList.Count == 0)
            {
                foldersList.Add(".");
            }

            foreach (var folder in destinationFolders)
            {
                foldersList.Add(folder);
            }

            return string.Join("/", foldersList) + "/" + fileName;
        }

        static string[] SplitToFolders(string source)
        {
            string wihtoutBackslashes = source.Replace('\\', '/');

            string withoutSlashes = wihtoutBackslashes.Trim('/');

            return withoutSlashes.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}