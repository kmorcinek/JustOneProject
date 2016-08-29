using System;

namespace JustOneProject.VariousStuff.ExampleEnums
{
    public class Example
    {
        public void Execute(DocumentStatus documentStatus)
        {
            try
            {
                switch (documentStatus)
                {
                    case DocumentStatus.Draft:
                        // Do sth
                        break;
                    case DocumentStatus.Released:
                        // Do sth
                        break;
                    default:
                        throw Guards.CreateMissingEnumException(nameof(documentStatus), documentStatus);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {

                throw;
            }
        }

        WorseDocumentStatus AssignInvalidValue()
        {
            return (WorseDocumentStatus) 111;
        }
    }
}