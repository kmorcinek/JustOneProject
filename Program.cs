using System;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Threading.Tasks;
using JustOneProject.Async;
using JustOneProject.VariousStuff;

namespace JustOneProject
{
    public class Program
    {
        public readonly TimeSpan AnimationDelay = TimeSpan.FromSeconds(5);

        private static double Foo(double b)
        {
            double a = 6;
            double c = a / b;

            return (int)c;
        }

        [STAThread]
        private static void Main()
        {
            //new AttachingToAction().Foo();
            new TestAttachingFromOutside().Foo();

            double b = Foo(0.0);

            var usingCalledThenReturned = new UsingCalledThenReturned();
            usingCalledThenReturned.Test();
            var usingWithNullValue = new UsingWithNullValue();
            usingWithNullValue.Test();
            new GitPatchesGenerator().GeneratePatches(@"C:\Work\SMT\RL\");

            var enumerable = Enumerable.Range(1, 36);
            var @join = string.Join(",", enumerable);

            //var bloombergPuzzle = new BloombergPuzzle();
            //var foo = bloombergPuzzle.Foo();
            //Console.WriteLine(foo);
            var tryAsyncWrapper = new TryAsyncWrapper();
            tryAsyncWrapper.Try();

            Console.ReadLine();

        }
    }

    public enum BoardTile
    {
        Empty = 0,
        Regular = 1,
        Fortified = 2,
        Indestructible = 3
    }
}