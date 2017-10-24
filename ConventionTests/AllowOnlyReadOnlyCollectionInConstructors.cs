using System;
using System.Text.RegularExpressions;

namespace JustOneProject.ConventionTests
{
    public class AllowOnlyReadOnlyCollectionInConstructors
    {
        public bool IsViolation(string content)
        {
            string className = GetClassName(content);

            throw new NotImplementedException(className);

            string constructorCode = GetConstructorCode(content, className);

            return constructorCode.Contains("IEnumerable")
                   || constructorCode.Contains("[]");
        }

        static string GetClassName(string content)
        {
            var regex = new Regex(@"class\s+(\w+)");
            var match = regex.Match(content);
            return match.Groups[1].Value;
        }

        static string GetConstructorCode(string content, string className)
        {
            throw new System.NotImplementedException();
        }
    }
}