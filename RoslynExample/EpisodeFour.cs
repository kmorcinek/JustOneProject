using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynExample
{
    class EpisodeFour
    {
        static void Main()
        {
            var tree = CSharpSyntaxTree.ParseText(@"
class C
{
    void Method()
    {
        if(true)
            Console.WriteLine(""Was here"");
    }
}
");
            var root = tree.GetRoot();

            //var rewriter = new MyRewriter();
            //var newRoot = rewriter.Visit(root);

            var ifStatements = root.DescendantNodes().OfType<IfStatementSyntax>();

            foreach (var ifStatement in ifStatements)
            {
                var body = ifStatement.Statement;
                var block = SyntaxFactory.Block(body);
                var newIfStatement = ifStatement.WithStatement(block);

                root = root.ReplaceNode(ifStatement, newIfStatement);
            }
        }
    }

    public class MyRewriter : CSharpSyntaxRewriter
    {
        public override SyntaxNode VisitIfStatement(IfStatementSyntax node)
        {
            var body = node.Statement;
            var block = SyntaxFactory.Block(body);
            var newIfStatement = node.WithStatement(block);

            return newIfStatement;
        }
    }
}