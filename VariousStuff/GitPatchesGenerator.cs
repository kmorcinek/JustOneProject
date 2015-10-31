using System.IO;
using System.Text;

namespace JustOneProject.VariousStuff
{
    public class GitPatchesGenerator
    {
        public void GeneratePatches(string directoryPath)
        {
            var inputFile = Path.Combine(directoryPath + "my_hashes.txt");
            var lines = File.ReadAllLines(inputFile);

            StringBuilder sb = new StringBuilder();

            foreach (var hash in lines)
            {
                sb.AppendLine("git format-patch -1 " + hash);
            }

            var outputFile = Path.Combine(directoryPath, "patches.cmd");
            File.WriteAllText(outputFile, sb.ToString());
        }
    }
}