using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace JustOneProject.Extensions
{
    public static class TaskExtensions
    {
        public static ConfiguredTaskAwaitable<T> ConfigureAwaitWithoutReturnToContext<T>(this Task<T> task)
        {
            return task.ConfigureAwait(continueOnCapturedContext: false);
        }

        public static ConfiguredTaskAwaitable ConfigureAwaitWithoutReturnToContext(this Task task)
        {
            return task.ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}