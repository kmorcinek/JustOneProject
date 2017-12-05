using System;
using System.Linq;

namespace JustOneProject.TsImportsGenerator
{
    class IdentifiersParser
    {
        public static string[] GetWords(string content)
        {
            char[] delimiters = " ;[],().<>".ToCharArray();

            string[] results = content.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            return results
                .Select(x => x.Replace(Environment.NewLine, string.Empty))
                .Where(x => string.IsNullOrWhiteSpace(x) == false)
                .Distinct()
                .ToArray();
        }
    }
}