using System;
using System.Threading;
using System.Threading.Tasks;

namespace JustOneProject.Async
{
    public class TryAsyncWrapper
    {
        public async void Try()
        {
            int color = 54;
            WrapLoadingAsync(async () =>
            {
                await Task.Run(async () =>
                {
                    color = await Task.Run(() => RunSynchronousJob());
                }).ContinueWith(delegate
                {
                    Console.WriteLine("jestem w Continue");
                    Console.WriteLine(color);
                });
            });

            Console.WriteLine("Po continue");
        }

        private static int RunSynchronousJob()
        {
            Console.WriteLine("Synchronous job started ...");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine("Synchronous job finished");
            return 7;
        }

        private static void ShowModalDialog()
        {
            
        }

        public async static Task WrapLoadingAsync(Func<Task> func)
        {
            Console.WriteLine("ShowLoading()");
            await func();
            Console.WriteLine("HideLoading()");
        }

        public static void DoAndStay(Action action)
        {
            Console.WriteLine("start");
            action();
            Console.WriteLine("finish");
        }
    }
}