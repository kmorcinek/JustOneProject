namespace JustOneProject.ConventionTests
{
    public class AllowOnlyReadOnlyCollectionInConstructors
    {
        public bool IsViolation(string content)
        {
            string className = GetClassName(content);

            string constructorCode = GetConstructorCode(content, className);

            return constructorCode.Contains("IEnumerable")
                   || constructorCode.Contains("[]");
        }

        static string GetClassName(string content)
        {
            throw new System.NotImplementedException();
        }

        static string GetConstructorCode(string content, string className)
        {
            throw new System.NotImplementedException();
        }
    }
}