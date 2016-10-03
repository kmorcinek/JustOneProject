using Xunit;

namespace JustOneProject.VariousStuff
{
    public class ConvertDoubleToDecimalProblemTests
    {
        [Theory]
        [Trait("Category", "DoNotRun")]
        [InlineData(1.3)]
        [InlineData(double.MinValue)]
        [InlineData(double.MaxValue)]
        public void Foo(double doubleValue)
        {
            ConvertToDecimalAndBack(doubleValue);
        }

        [Fact]
        [Trait("Category", "DoNotRun")]
        public void Test()
        {
            double value = 0.000001d;
            value *= 10;
//            Console.WriteLine(value); // 9.9999999999999991E-06
            ConvertToDecimalAndBack(value);
        }

        private static void ConvertToDecimalAndBack(double doubleValue)
        {
            decimal decimalValue = (decimal)doubleValue;

            double doubleResult = (double)decimalValue;

            Assert.Equal(doubleValue, doubleResult);
        }
    }
}