using Ploeh.AutoFixture;
using Xunit;

namespace JustOneProject.AutoFixtureExamples
{
    public class ExampleTest
    {
        [Fact]
        public void Foo()
        {
            ImmutableExample old = CreateWithAge(56);
            ImmutableExample young = CreateWithAge(16);

            // ...
        }

        static ImmutableExample CreateWithAge(int age)
        {
            return new Fixture().Create<ImmutableExample>().WithAge(age);
        }
    }
}