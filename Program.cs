using System;

namespace JustOneProject
{
    public class Program
    {
        [STAThread]
        private static void Main()
        {
            var program = new FileUrlsGenerator();
            program.Run();
            var filesDownloader = new FilesDownloader("http://www.secret.com", "locations.xml", @"downloads\");
            filesDownloader.Run();
        }
    }
}