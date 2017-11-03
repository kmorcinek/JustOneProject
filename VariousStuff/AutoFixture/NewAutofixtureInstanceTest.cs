using System.Collections.Generic;
using Ploeh.AutoFixture;
using Xunit;

namespace JustOneProject.VariousStuff.AutoFixture
{
    public class NewAutofixtureInstanceTest
    {
        [Fact]
        public void Each_instance_generates_new_ints()
        {
            var a = new Fixture().Create<byte>();
            var b = new Fixture().Create<byte>();

            // It will sometimes fail with 1/256 probability
            Assert.Equal(a, b);
        }

        [Fact]
        public void Same_instance_will_not_repeat_values()
        {
            var hashSet = new Dictionary<byte, object>();

            var fixture = new Fixture();

            for (int i = 0; i < byte.MaxValue - 1; i++)
            {
                var value = fixture.Create<byte>();

                hashSet.Add(value, null);
            }

            // In the same Fixture generated number will not be repeated
        }
    }
}