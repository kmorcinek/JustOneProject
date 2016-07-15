using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JustOneProject.Diagnostics;

namespace JustOneProject.Tasks
{
    public class RunTaskInParallelWithCancellationToken
    {

        public static void Run()
        {
            var array = Enumerable.Range(0, 5);

            CancellationTokenSource cts = new CancellationTokenSource();
            List<Task> tasks = new List<Task>();

            foreach (var index in array)
            {
                tasks.Add(Task.Factory.StartNew(() => {
                    try
                    {
                        DoJob(index);
                    }
                    catch (OperationCanceledException)
                    {
                        // Swallow ex 
                    }
                    catch (Exception ex)
                    {
                        // Log
                        cts.Cancel();
                        // Do not re-throw because this runs inside a task and this would not be caught anywhere
                    }
                }, cts.Token));
            }

            try
            {
                Task.WaitAll(tasks.ToArray(), cts.Token);
            }
            catch (Exception ex)
            {
                
            }

            Console.ReadLine();
        }

        private static void DoJob(int index)
        {
            LoggingDiagnostics.LogMessage($"Started {index}");

            Task.Delay(TimeSpan.FromSeconds(2)).Wait();

            if (index == 2)
            {
                throw new NotImplementedException("boo");
            }

            for (int i = 0; i < 3; i++)
            {
                Task.Delay(TimeSpan.FromSeconds(index)).Wait();
            }

            LoggingDiagnostics.LogMessage($"Finished {index}");
        }
    }
}