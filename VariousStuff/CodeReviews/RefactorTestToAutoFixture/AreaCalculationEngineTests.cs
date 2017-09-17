using FluentAssertions;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace JustOneProject.VariousStuff.CodeReviews.RefactorTestToAutoFixture
{
    public class AreaCalculationEngineTests
    {
        [Theory]
        [AutoData]
        public void CalculateArea_works(
            double motorWidth,
            double returnedByLengthEngine)
        {
            var fixture = new Fixture();

            double expectedResult = motorWidth * returnedByLengthEngine;

            var lengthEngine = new Mock<ILengthEngine>();
            lengthEngine
                .Setup(engine => engine.CalculateLength(It.IsAny<double>(), It.IsAny<double>()))
                .Returns(returnedByLengthEngine);

            var sut = new AreaCalculationEngine(lengthEngine.Object);

            double area = sut.CalculateArea(motorWidth, fixture.Create<double>(), fixture.Create<double>());

            area.Should().Be(expectedResult);
        }
    }
}