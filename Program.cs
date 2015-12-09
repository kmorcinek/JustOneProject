using System;
using System.Linq;
using System.Threading.Tasks;
using JustOneProject.Async;
using JustOneProject.VariousStuff;

namespace JustOneProject
{
    public class Program
    {
        public readonly TimeSpan AnimationDelay = TimeSpan.FromSeconds(5);

        [STAThread]
        private static void Main()
        {
            var usingCalledThenReturned = new UsingCalledThenReturned();
            usingCalledThenReturned.Test();
            var usingWithNullValue = new UsingWithNullValue();
            usingWithNullValue.Test();
            new GitPatchesGenerator().GeneratePatches(@"C:\Work\SMT\RL\");
            BoardTile[,] board;

            board = new BoardTile[5,3];
            Task.Delay()
            var length = board.GetLength(0);
            var length2 = board.GetLength(1);

            
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