using System;

namespace JustOneProject.Presentation
{
    public class ObsoleteEquals
    {
        public void Foo()
        {
            const string user = "John";
            var input = Console.ReadLine();

            if (user.Equals(input))
            {
                Console.WriteLine("Entered correct user");
            }

            if (user.Equals(input))
            {
                Console.WriteLine("Entered correct user");
            }

            if (user.Equals(input))
            {
                Console.WriteLine("Entered correct user");
            }

        }
    }
}