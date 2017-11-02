using System.Collections.Generic;

namespace JustOneProject.VariousStuff.Casting
{
    public class CastingTest
    {
        static void Main()
        {
            var dictionary = new MyDictionary(new Dictionary<int, int>());

            IMyInterface implicitObject = dictionary;
        }
    }
}