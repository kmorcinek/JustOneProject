using System.IO;
using System.Text;

namespace JustOneProject.VariousStuff
{
    public class FileConcatenator
    {
        public void Concat(string path, string pattern)
        {
            var enumerateFiles = Directory.EnumerateFiles(path, pattern);

            var sb = new StringBuilder();
            foreach (var file in enumerateFiles)
            {
                var readAllText = File.ReadAllText(file);
                sb.AppendLine(readAllText);
            }

            File.WriteAllText("out.sql", sb.ToString());
        }
    }
}