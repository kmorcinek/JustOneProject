using System;
using System.Collections.Generic;

namespace JustOneProject.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ForEachWithIndex<T>(this IEnumerable<T> enumerable, Action<T, int> handler)
        {
            var index = 0;
            foreach (var item in enumerable)
            {
                handler(item, index);
                index++;
            }
        }
    }
}