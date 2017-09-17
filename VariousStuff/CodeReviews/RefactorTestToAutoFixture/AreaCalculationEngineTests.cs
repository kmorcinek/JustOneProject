using FluentAssertions;
using Moq;
using Ploeh.AutoFixture;
using Xunit;

namespace JustOneProject.VariousStuff.CodeReviews.RefactorTestToAutoFixture
{
    public class AreaCalculationEngineTests
    {
        [Fact]
        public void CalculateArea_works()
        {
            var fixture = new Fixture();

            double motorWidth = fixture.Create<double>();
            double lengthReturnedByLengthEngine = fixture.Create<double>();

            var lengthEngine = new Mock<ILengthEngine>();
            lengthEngine
                .Setup(engine => engine.CalculateLength(It.IsAny<double>(), It.IsAny<double>()))
                .Returns(lengthReturnedByLengthEngine);

            var sut = new AreaCalculationEngine(lengthEngine.Object);

            double area = sut.CalculateArea(motorWidth, fixture.Create<double>(), fixture.Create<double>());

            area.Should().Be(motorWidth * lengthReturnedByLengthEngine);
        }
    }
}