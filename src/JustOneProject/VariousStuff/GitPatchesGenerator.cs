using System.IO;
using System.Text;

namespace JustOneProject.VariousStuff
{
    public class GitPatchesGenerator
    {
        public void GeneratePatches(string directoryPath)
        {
            var pathHashesFile = directoryPath + "my_hashes.txt";
            var inputFile = Path.Combine(pathHashesFile);
            var lines = File.ReadAllLines(inputFile);

            StringBuilder sb = new StringBuilder();

            AppendLInes(lines, sb);

            var outputFile = Path.Combine(directoryPath, "patches.cmd");
            File.WriteAllText(outputFile, sb.ToString());
        }

        private static void AppendLInes(string[] lines, StringBuilder sb)
        {
            foreach (var hash in lines)
            {
                sb.AppendLine("git format-patch -1 " + hash);
            }
        }
    }
}