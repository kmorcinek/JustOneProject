using System.Collections.Generic;

namespace JustOneProject.VariousStuff.Casting
{
    public class MyDictionary : Dictionary<int, int>, IMyInterface
    {
        public MyDictionary(IDictionary<int, int> dictionary) : base(dictionary)
        {
        }
    }
}