using System;
using System.Threading;
using System.Threading.Tasks;
using JustOneProject.IoC;
using JustOneProject.StyleCop;
using JustOneProject.TsImportsGenerator;
using JustOneProject.VariousStuff;
using Ninject;
using Ninject.Extensions.Conventions;
using Xunit.Sdk;

namespace JustOneProject
{
    public class Program
    {
        static readonly AutoResetEvent _autoResetEvent = new AutoResetEvent(false);

        static void Main()
        {
            RewriteRulesetTests.Test();
            return;

            TsImportsGeneratorRunner.Run(@"C:\SRC\Prime\ServerApplication\Main\BomWebApplication\ABB.BomManager.WebApp\Scripts");
            return;

            _autoResetEvent.Set();
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    _autoResetEvent.WaitOne();

                    Console.WriteLine("konik");
                }
            });


            //while (true)
            //{
            //    Console.ReadLine();
            //    _autoResetEvent.Set();
            //}
            var generateCalculations = new GenerateCalculations();
            var one = generateCalculations.GetOne();
            var kernel = new StandardKernel();
            //kernel.Bind<IService>().To<Service>();
            kernel.Bind(x =>
            {
                x.FromThisAssembly() // Scans currently assembly
                 .SelectAllClasses().EndingWith("Service") // Retrieve all non-abstract classes
                 .BindDefaultInterface(); // Binds the default interface to them;
            });
            var service = kernel.Get<IService>();
        }
    }
}