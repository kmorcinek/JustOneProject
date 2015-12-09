using System;

namespace JustOneProject.VariousStuff
{
    public class MyResource : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Disposable");
        }
    }
}