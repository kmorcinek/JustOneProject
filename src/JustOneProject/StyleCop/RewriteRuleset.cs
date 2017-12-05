using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace JustOneProject.StyleCop
{
    class RewriteRuleset
    {
        public void Do(string releasePath, string debugPath, string outputXml)
        {
            var releaseRules = ReadFromFile<Rule[]>(releasePath);
            var debugRules = ReadFromFile<Rule[]>(debugPath);

            Rule[] transformed = Transform(releaseRules, debugRules);

            WriteToFile(transformed, outputXml);
        }

        public Rule[] Transform(Rule[] releaseRules, Rule[] debugRules)
        {
            var debugIds = debugRules.Select(x => x.Id).ToArray();

            foreach (var rule in releaseRules)
            {
                if (debugIds.Contains(rule.Id))
                {
                    rule.Action = "None";
                } 
            }

            return releaseRules;
        }

        static T ReadFromFile<T>(string filePath)
        {
            XmlSerializer serializerObj = new XmlSerializer(typeof(T));

            using (var stream = new StreamReader(filePath))
            {
                return (T)serializerObj.Deserialize(stream);
            }
        }

        static void WriteToFile<T>(T data, string filePath)
        {
            XmlSerializer serializerObj = new XmlSerializer(typeof(T));

            using (TextWriter writeFileStream = new StreamWriter(filePath))
            {
                serializerObj.Serialize(writeFileStream, data);
            }
        }
    }
}