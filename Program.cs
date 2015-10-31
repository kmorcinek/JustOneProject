using System;
using JustOneProject.VariousStuff;

namespace JustOneProject
{
    public class Program
    {
        [STAThread]
        private static void Main()
        {


            new GitPatchesGenerator().GeneratePatches(@"C:\Work\SMT\RL\");
        }
    }
}