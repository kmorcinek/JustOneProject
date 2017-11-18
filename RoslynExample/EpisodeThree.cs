using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace RoslynExample
{
    class EpisodeThree
    {
        static void Main()
        {
            var myWalker = new MyWalker();

            var tree = CSharpSyntaxTree.ParseText(@"
class C
{
    void Method()
    {
        // this is method
    }
}
");
            var root = tree.GetRoot();

            myWalker.Visit(root);

            var result = myWalker.sb.ToString();
        }
    }

    public class MyWalker : CSharpSyntaxWalker
    {
        public MyWalker()
            : base(SyntaxWalkerDepth.Token)
        {
        }

        public StringBuilder sb = new StringBuilder();

        public override void VisitToken(SyntaxToken token)
        {
            sb.Append(token.ToString());
        }
    }
}