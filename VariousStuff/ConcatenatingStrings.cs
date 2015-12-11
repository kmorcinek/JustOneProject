using System.Text;

namespace JustOneProject.VariousStuff
{
    public class ConcatenatingStrings
    {
        public void Foo()
        {
            var names = new[] { "john", "james", "robin" }; // and many, many more

            // This is how I was doing it by always default
            var sb = new StringBuilder();
            foreach (var name in names)
            {
                sb.Append(name);
            }
            sd
            var result = sb.ToString();

            // This is better cause of readability
            var result2 = string.Concat(names);
        }
    }
}