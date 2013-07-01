using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;

namespace JustOneProject
{
    public class FilesDownloader
    {
        private readonly string _baseUrl;
        private readonly string _locationsXmlPath;
        private readonly string _localFolder;

        public FilesDownloader(string baseUrl, string locationsXmlPath, string localFolder)
        {
            _baseUrl = baseUrl;
            _localFolder = localFolder;
            _locationsXmlPath = locationsXmlPath;
        }

        public void Run()
        {
            var files = GetUrlsFromXml();
            DownloadFiles(files);
        }

        IEnumerable<string> GetUrlsFromXml()
        {
            var doc = new XmlDocument();
            doc.Load(_locationsXmlPath);

            return Parse(doc.DocumentElement);
        }

        void DownloadFiles(IEnumerable<string> files)
        {
            using (var client = new WebClient())
            {
                foreach (var file in files)
                {
                    var fileName = _localFolder + file;

                    var directoryName = Path.GetDirectoryName(fileName);
                    Directory.CreateDirectory(directoryName);

                    var fullUrl = _baseUrl + file;
                    try
                    {
                        client.DownloadFile(fullUrl, fileName);
                    }
                    catch (WebException exception)
                    {
                        Console.WriteLine("Problems with downloading {0}: {1}", fullUrl, exception.Message);
                    }
                }
            }
        }

        private static IEnumerable<string> Parse(XmlElement element)
        {
            var name = element.Name;
            var xmlAttribute = element.Attributes["files"];

            var list = new List<string>();

            Func<string, string> selector = s => name + "/" + s;
            if (xmlAttribute != null)
            {
                list.AddRange(xmlAttribute.Value.Split(';').Select(selector));
            }

            foreach (XmlNode childNode in element.ChildNodes)
            {
                list.AddRange(Parse(childNode as XmlElement).Select(selector));
            }

            return list;
        }
    }
}