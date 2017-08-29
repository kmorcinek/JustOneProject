using System;
using Ploeh.AutoFixture;

namespace JustOneProject.AutoFixtureExamples
{
    public class AutoFixtureRunner
    {
        public static void Run()
        {
            Fixture fixture = new Fixture();

            ImmutableExample value = fixture.Create<ImmutableExample>();

            Console.WriteLine(value.Name);
            Console.WriteLine(value.Age);

            ImmutableExample changedValue = value.WithAge(4);

            Console.WriteLine(changedValue.Age);

            Console.ReadLine();
        }
    }
}