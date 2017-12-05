using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynExample
{
    class EpisodeTwo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var tree = CSharpSyntaxTree.ParseText(@"
class C
{
    void Method()
    {
        // this is method
    }
}
");

            //var diagnostics = tree.GetDiagnostics().Where(x => x.Severity == DiagnosticSeverity.Error).First();

            var root = tree.GetRoot();
            var method = root.DescendantNodes().OfType<MethodDeclarationSyntax>().First();

            var returnTYpe = SyntaxFactory.ParseTypeName("string");

            var newMethod = method.WithReturnType(returnTYpe);
        }
    }
}
