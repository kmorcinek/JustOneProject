using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml.Serialization;

namespace JustOneProject.StyleCop
{
    public class Rule
    {
        [XmlAttribute]
        public string Id { get; set; }
        [XmlAttribute]
        public string Action { get; set; }
    }
}