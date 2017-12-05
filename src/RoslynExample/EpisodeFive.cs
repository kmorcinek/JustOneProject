using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynExample
{
    class EpisodeFive
    {
        static void Main()
        {
            var tree = CSharpSyntaxTree.ParseText(@"
            public partial class MyPartialClass
            {
                void Method()
                {
                    System.Console.WriteLine(""Was here"");
                }
            }

            public partial class MyPartialClass
            {
            }
");

            var mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
            var compilation = CSharpCompilation.Create("MyCompilation",
                syntaxTrees: new[] { tree },
                references: new[] { mscorlib });

            var root = tree.GetRoot();

            var semanticModel = compilation.GetSemanticModel(tree);
            var methodSyntax = root.DescendantNodes().OfType<MethodDeclarationSyntax>().Single();

            //var firstClass = root.DescendantNodes().OfType<ClassDeclarationSyntax>().First();
            //var secondClass = root.DescendantNodes().OfType<ClassDeclarationSyntax>().Last();

            //var firstSymbol = semanticModel.GetDeclaredSymbol(firstClass);
            //var secondSymbol = semanticModel.GetDeclaredSymbol(secondClass);

            //var areEqual = firstSymbol == secondSymbol;

            var methodSymbol = semanticModel.GetDeclaredSymbol(methodSyntax);

            var invokedMethod = root.DescendantNodes().OfType<InvocationExpressionSyntax>().Single();
            var symbolInfo = semanticModel.GetSymbolInfo(invokedMethod);
            var invokedSymbol = symbolInfo.Symbol; // as IMethodSymbol;

            var containingAssembly = invokedSymbol.ContainingAssembly;
        }
    }
}