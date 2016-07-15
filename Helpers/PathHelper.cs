using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace JustOneProject.Helpers
{
    public static class PathHelper
    {
        public static void EnsureDirectoryExists(string filePath)
        {
            var directoryPath = Path.GetDirectoryName(filePath);
            Directory.CreateDirectory(directoryPath);
        }

        public static string ComputeHash(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return string.Concat(md5.ComputeHash(stream).Select(x => x.ToString("X2")));
                }
            }

        }

        public static string ComputeHashSimpler(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return Encoding.Unicode.GetString(md5.ComputeHash(stream));
                }
            }
        }
    }
}