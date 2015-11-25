using System;
using System.Collections.Generic;
using System.Linq;
using JustOneProject.Async;
using JustOneProject.VariousStuff;

namespace JustOneProject
{
    public class Program
    {
        [STAThread]
        private static void Main()
        {
            var enumerable = Enumerable.Range(1, 36);
            var @join = string.Join(",", enumerable);

            //var bloombergPuzzle = new BloombergPuzzle();
            //var foo = bloombergPuzzle.Foo();
            //Console.WriteLine(foo);
            var tryAsyncWrapper = new TryAsyncWrapper();
            tryAsyncWrapper.Try();

            Console.ReadLine();

            new GitPatchesGenerator().GeneratePatches(@"C:\Work\SMT\RL\");
        }
    }
}