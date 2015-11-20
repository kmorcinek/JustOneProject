using System;
using System.Collections.Generic;
using System.Linq;

namespace JustOneProject.Presentation
{
    public class Side
    {
        void Foo()
        {
            if (0 > 5)
            {
                Console.WriteLine("hello PWR");
            }

            var names = new List<string>();

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            var firstName = names.FirstOrDefault();

            try
            {
                Console.WriteLine(firstName.ToLower());
                Console.WriteLine(firstName.ToLower());
                Console.WriteLine(firstName.ToLower());
                Console.WriteLine(firstName.ToLower());
                Console.WriteLine(firstName.ToLower());
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}