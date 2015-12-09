using System;

namespace JustOneProject.VariousStuff
{
    public class UsingWithNullValue
    {
        public void Test()
        {
            using (var image = GetImage())
            {
                if (image == null)
                {
                    Console.WriteLine("null");
                }
            }
        }

        private IDisposable GetImage()
        {
            return null;
        }
    }
}