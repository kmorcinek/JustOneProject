using System;
using System.Text.RegularExpressions;

namespace JustOneProject.TsImportsGenerator
{
    class RetrieveClassName
    {
        public static string GetClassName(string content)
        {
            Regex regex = new Regex(@"export (?:\bclass\b|\binterface\b) (\w+)");

            Match match = regex.Match(content);

            if (match.Success == false)
            {
                throw new ArgumentException($"Cannot find class name in '{content}'");
            }

            return match.Groups[1].Value;
        }
    }
}