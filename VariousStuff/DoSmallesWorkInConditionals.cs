using System.Collections.Generic;
using System.Linq;

namespace JustOneProject.VariousStuff
{
    public class DoSmallesWorkInConditionals
    {
        public void Foo()
        {
            if (HasInternalDocuments(AdditionalDocuments))
            {
                AdditionalDocumentsGroup = new AdditionalDocumentsGroup(AdditionalDocuments);
            }
            else
            {
                AdditionalDocumentsGroup = new AdditionalDocumentsGroup(new List<Document>());
            }
        }

        public void BetterFoo()
        {
            IEnumerable<Document> internalDocuments;

            if (HasInternalDocuments(AdditionalDocuments))
            {
                internalDocuments = AdditionalDocuments;
            }
            else
            {
                internalDocuments = new List<Document>();
            }

            AdditionalDocumentsGroup = new AdditionalDocumentsGroup(internalDocuments);
        }

        public void EvenBetterFoo()
        {
            var internalDocuments = HasInternalDocuments(AdditionalDocuments)
                ? AdditionalDocuments
                : Enumerable.Empty<Document>();

            AdditionalDocumentsGroup = new AdditionalDocumentsGroup(internalDocuments);
        }

        public AdditionalDocumentsGroup AdditionalDocumentsGroup { get; set; }

        public List<Document> AdditionalDocuments { get; set; }

        private static bool HasInternalDocuments(List<Document> additionalDocuments)
        {
            return additionalDocuments.Any(x => x.DocumentSubtype != Subtype.Internall);
        }
    }

    public class AdditionalDocumentsGroup
    {
        public AdditionalDocumentsGroup(IEnumerable<Document> objects)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Document
    {
        public Subtype DocumentSubtype { get; set; }
    }

    public enum Subtype
    {
        Internall
    }
}