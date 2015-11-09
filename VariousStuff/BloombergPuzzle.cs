using System;

namespace JustOneProject.VariousStuff
{
    public class BloombergPuzzle
    {
        public int Foo()
        {
            int v = 0;
            int n = 10;
            for (int i = 0; i < n; --i)
            {
                v += 1;
            }

            Console.WriteLine(v);
            return v;
        } 

        // Add/Change one character to make Foo() return 10.
        // Zadanie jest w C. 
        // 5 rozwiazań znam. 4 są "algorytniczne", w tym tylko jedno z nich wymaga znajomości podstaw co bo w C# to by nie wyszło. Jedno jest mimo że logiczne to trochę mniej oczywiste, a przez niektórych uważane za hack.

        // return n;
        // i + n
        // -i < n
        // --n
        // v < n
    }
}