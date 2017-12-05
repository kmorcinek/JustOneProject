using System;
using System.Threading.Tasks;

namespace JustOneProject.Async
{
    public class LoggingWrapper
    {
        public async Task<long> InitializeProductDefinitionDownload()
        {
            Func<Task<long>> func = async () =>
            {
                Console.WriteLine("Starting download of product definition...");

                var uri = "uri";
                var l = await GetData(uri);

                Console.WriteLine("Starting download of product definition...");
                return l;
            };

            var task = await func();
            return task;
        }

        private Task<long> GetData(string uri)
        {
            Task.Delay(TimeSpan.FromSeconds(5)).Wait();

            throw new NotImplementedException("nie");
        }
    }
}