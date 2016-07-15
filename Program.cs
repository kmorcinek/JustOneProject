using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JustOneProject.Async;
using JustOneProject.Diagnostics;
using JustOneProject.Helpers;
using JustOneProject.VariousStuff;

namespace JustOneProject
{
    public class Program
    {
        public readonly TimeSpan AnimationDelay = TimeSpan.FromSeconds(5);

        private static MemoryGuard _memoryGuard = new MemoryGuard();

        private static double Foo(double b)
        {
            double a = 6;
            double c = a / b;

            return (int)c;
        }

        [STAThread]
        private static void Main()
        {
            var computeHash = PathHelper.ComputeHash(@"C:\Users\PLKRMOR\Desktop\Error Handling.txt");
            TestMemoryConsumption();
            return;
            LoggingDiagnostics.LogWithCurrentLocalTime("tesraz");
            LoggingDiagnostics.LogWithCurrentLocalTimeAndCurrentMethod();
            //HowWouldItRun.WillRunSynchronously();
            //HowWouldItRun.WillRunAsynchronously();
            //HowWouldItRun.InvokeSynchronousAction();
            //HowWouldItRun.InvokeAsyncActionWillRunAsynchronously();
            HowWouldItRun.CheatingMyselfWithAsync();

            Console.ReadLine();

            new GitPatchesGenerator().GeneratePatches(@"C:\Work\SMT\RL\");
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

        private static void TestMemoryConsumption()
        {
            const int length = 64 * 1000 * 1000;
            var array = new byte[length];
            array[9999] = 33;
            var arrayForAdding = new byte[15 * 1000 * 1000];
            arrayForAdding[9999] = 33;

            for (int i = 0; i < 8; i++)
            {
                array = Merge(array, arrayForAdding);
            }

            arrayForAdding = new byte[15 * 1000 * 1000];
            
            for (int i = 0; i < 8 * 2; i++)
            {
                array = Merge(array, arrayForAdding);
            }

        }

        private static byte[] Merge(byte[] data, byte[] bytesToAppend)
        {
            if (data == null)
            {
                return bytesToAppend;
            }

            if (bytesToAppend == null)
            {
                return data;
            }

            var newArrayLength = data.Length + bytesToAppend.Length;
            var message = "Merge: newArrayLength = " + newArrayLength / (1000 * 1000);
            Debug.WriteLine(message);

            PrintMemoryUsedByGC();
            _memoryGuard.UpdateArrayLengthAndCallGcWhenAppropriate(newArrayLength);

            byte[] result = new byte[newArrayLength];
            Array.Copy(data, 0, result, 0, data.Length);
            Array.Copy(bytesToAppend, 0, result, data.Length, bytesToAppend.Length);
            Wait();
            return result;
        }

        private static void Wait()
        {
            Task.Delay(TimeSpan.FromSeconds(1)).Wait();
        }

        private static void PrintMemoryUsedByGC()
        {
            long totalMemory = GC.GetTotalMemory(false) / 1024;
            Debug.WriteLine("Total memory in KB: " + totalMemory);
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