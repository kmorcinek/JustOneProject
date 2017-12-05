using System;
using System.Threading.Tasks;

namespace JustOneProject.Async
{
    public class HowWouldItRun
    {
        // Timeout is just to show that other operation will complete earlier
        public static void WillRunAsynchronously()
        {
            Task.Run(() =>
            {
                Task.Delay(TimeSpan.FromSeconds(1)).Wait(); // Blocking thread

                Log("inside Task.Run");
            });

            Log("after Task.Run");
        }

        public static async Task WillRunSynchronously()
        {
            await Task.Run(() =>
            {
                Task.Delay(TimeSpan.FromSeconds(1)).Wait(); // Blocking thread

                Log("inside Task.Run");
            });

            Log("after Task.Run");
        }

        public static async Task CheatingMyselfWithAsync()
        {
            // Actually it will work as Task.Run have an overload with Func<Task> and will handle this 'async' correctly
            await Task.Run(async () =>
            {
                Task.Delay(TimeSpan.FromSeconds(1)).Wait(); // Blocking thread

                Log("inside Task.Run");
            });

            Log("after Task.Run");
        }

        private static void Log(string message)
        {
            Console.WriteLine(message);
        }

        public static void InvokeSynchronousAction()
        {
            RunSynchronouslyInOtherContext(() =>
            {
                Task.Delay(TimeSpan.FromSeconds(1)).Wait(); // Blocking thread

                Log("inside Task.Run");
            });

            Log("after Task.Run");
        }

        public static void InvokeAsyncActionWillRunAsynchronously()
        {
            RunSynchronouslyInOtherContext(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(1)); // NOT blocking thread

                Log("inside Task.Run");
            });

            Log("after Task.Run");
        }

        private static void RunSynchronouslyInOtherContext(Action action)
        {
            // for example wrapped in try catch
            action();
        }
    }
}