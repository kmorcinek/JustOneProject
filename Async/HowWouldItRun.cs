using System;
using System.Threading.Tasks;

namespace JustOneProject.Async
{
    public class HowWouldItRun
    {
        public static void WillRunAsynchronously()
        {
            Task.Run(() =>
            {
                Task.Delay(TimeSpan.FromSeconds(1)).Wait(); // Blocking Thread

                Log("inside Task.Run");
            });

            Log("after Task.Run");
        }

        public static async Task WillRunSynchronously()
        {
            await Task.Run(() =>
            {
                Task.Delay(TimeSpan.FromSeconds(1)).Wait(); // Blocking Thread

                Log("inside Task.Run");
            });

            Log("after Task.Run");
        }

        private static void Log(string message)
        {
            Log(message);
        }

        public static async Task InvokeSynchronousAction()
        {
            RunSynchronouslyInOtherContext(() =>
            {
                Task.Delay(TimeSpan.FromSeconds(1)).Wait(); // Blocking Thread

                Log("inside Task.Run");
            });

            Log("after Task.Run");
        }

        public static async Task Invoke()
        {
            RunSynchronouslyInOtherContext(() =>
            {
                Task.Delay(TimeSpan.FromSeconds(1)).Wait();

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