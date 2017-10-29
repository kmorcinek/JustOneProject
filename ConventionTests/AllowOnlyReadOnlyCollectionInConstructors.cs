﻿using System.Text.RegularExpressions;

namespace JustOneProject.ConventionTests
{
    // This is not production code so I am using Regular Expression (hard to read).
    // TODO: works only if there is one class in the file
    public class AllowOnlyReadOnlyCollectionInConstructors
    {
        public bool IsViolation(string content)
        {
            Option<string> className = GetClassName(content);

            Option<string> constructorCode = className.IfSome(x => GetConstructorCode(content, x));

            if (constructorCode.HasValue == false)
            {
                return false;
            }

            return constructorCode.Value.Contains("IEnumerable")
                   || constructorCode.Value.Contains("[]");
        }

        public static Option<string> GetClassName(string content)
        {
            var regex = new Regex(@"class\s+(\w+)");

            Match match = regex.Match(content);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return Option<string>.None;
        }

        static Option<string> GetConstructorCode(string content, string className)
        {
            // TODO: the last ) should be lazy (smallest string possible)
            var regex = new Regex($@"\s+{className}\s*\((.*\))");

            Match match = regex.Match(content);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return Option<string>.None;
        }
    }
}