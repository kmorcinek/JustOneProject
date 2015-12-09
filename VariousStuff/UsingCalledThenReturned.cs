using System;

namespace JustOneProject.VariousStuff
{
    public class UsingCalledThenReturned
    {
        public void Test()
        {
            var myResource = GetFunc();

            Console.WriteLine("after GetFunc");
        }

        private MyResource GetFunc()
        {
            using (var resource = GetDisposableResource())
            {
                Console.WriteLine("Resource created after using");
                return resource;
            } 
        }

        private MyResource GetDisposableResource()
        {
            return new MyResource();
        }
    }
}