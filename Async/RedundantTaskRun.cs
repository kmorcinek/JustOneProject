using System;
using System.Threading.Tasks;

namespace JustOneProject.Async
{
    public class RedundantTaskRun
    {
        public async void Foo()
        {
            await WrapWithLoadingDialogAsync(async () =>
            {
                await Task.Run(async () =>
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    // Some real code
                });
            });
        }

        private Task WrapWithLoadingDialogAsync(Func<Task> func)
        {
            // Show loader
            var function = func();
            // hide loader 
            return function;
        }
    }
}