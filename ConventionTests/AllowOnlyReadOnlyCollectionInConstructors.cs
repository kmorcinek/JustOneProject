using System;
using System.Text.RegularExpressions;

namespace JustOneProject.ConventionTests
{
    // This is not production code so I am using Regular Expression (hard to read).
    // TODO: works only if there is one class in the file
    public class AllowOnlyReadOnlyCollectionInConstructors
    {
        public bool IsViolation(string content)
        {
            string className = GetClassName(content);

            string constructorCode = GetConstructorCode(content, className);

            //throw new NotImplementedException(constructorCode);

            return constructorCode.Contains("IEnumerable")
                   || constructorCode.Contains("[]");
        }

        static string GetClassName(string content)
        {
            var regex = new Regex(@"class\s+(\w+)");

            Match match = regex.Match(content);

            return match.Groups[1].Value;
        }

        static string GetConstructorCode(string content, string className)
        {
            // TODO: the last ) should be lazy (smallest string possible)
            var regex = new Regex($@"\s+BadClass\s*\((.*\))");

            Match match = regex.Match(content);

            return match.Groups[1].Value;
        }
    }
}