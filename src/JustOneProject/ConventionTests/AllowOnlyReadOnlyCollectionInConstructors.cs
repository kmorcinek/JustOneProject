using System.Text.RegularExpressions;

namespace JustOneProject.ConventionTests
{
    // This is not production code so I am using Regular Expression (hard to read).
    public class AllowOnlyReadOnlyCollectionInConstructors
    {
        public bool IsViolation(string content)
        {
            string className = GetClassName(content);

            if (className == null)
            {
                return false;
            }

            string constructorCode = GetConstructorParametersCode(content, className);

            if (constructorCode == null)
            {
                return false;
            }

            return constructorCode.Contains("IEnumerable")
                   || constructorCode.Contains("[]");
        }

        public static string GetClassName(string content)
        {
            var regex = new Regex(@"(class|struct)\s+(\w+)");

            Match match = regex.Match(content);

            if (match.Success)
            {
                return match.Groups[2].Value;
            }

            return null;
        }

        static string GetConstructorParametersCode(string content, string className)
        {
            var regex = new Regex($@"\s+{className}\s*\((.*\))");

            Match match = regex.Match(content);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return null;
        }
    }
}