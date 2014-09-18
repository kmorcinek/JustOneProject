using Microsoft.Xml.XMLGen;
using System;
using System.Xml;
using System.Xml.Schema;

namespace JustOneProject
{
    public class Program
    {
        [STAThread]
        private static void Main()
        {
            CreateXml();
        }

        private static void VerifyXmlWithSchema(string targetNamespace, string schemaUri, string xmlFilePath)
        {
            // Set the validation settings.
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.Schemas.Add(targetNamespace, schemaUri);
            settings.ValidationEventHandler += ValidationCallback;
            // Create the XmlReader object.
            XmlReader reader = XmlReader.Create(xmlFilePath, settings);

            // Parse the file. 
            while (reader.Read()) ;

            Console.ReadLine();
        }

        static void ValidationCallback(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                Console.Write("WARNING: ");
            else if (args.Severity == XmlSeverityType.Error)
                Console.Write("ERROR: ");

            Console.WriteLine(args.Message);
        }

        private static void CreateXml()
        {
            XmlTextWriter textWriter = new XmlTextWriter("po.xml", null);
            textWriter.Formatting = Formatting.Indented;
            XmlQualifiedName qname = new XmlQualifiedName("Deklaracja",
                                       "http://e-deklaracje.mf.gov.pl/Repozytorium/Deklaracje/PIT/PIT-11Z/");
            XmlSampleGenerator generator = new XmlSampleGenerator("http://e-deklaracje.mf.gov.pl/Repozytorium/Deklaracje/PIT/PIT-11Z/schemat.xsd", qname);
            generator.WriteXml(textWriter);
        }
    }
}