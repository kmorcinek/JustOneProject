using FluentAssertions;
using Moq;
using Xunit;

namespace JustOneProject.VariousStuff.CodeReviews.RefactorTestToAutoFixture
{
    public class AreaCalculationEngineTests
    {
        [Fact]
        public void CalculateArea_works()
        {
            double motorWidth = 250;
            double width = 250;
            double distance = 0;

            var lengthEngine = new Mock<ILengthEngine>();
            lengthEngine
                .Setup(engine => engine.CalculateLength(It.IsAny<double>(), It.Is<double>(v => v == motorWidth)))
                .Returns(1110);

            var sut = new AreaCalculationEngine(lengthEngine.Object);

            double area = sut.CalculateArea(motorWidth, width, distance);

            area.Should().Be(277500);
            lengthEngine.Verify(engine => engine.CalculateLength(It.IsAny<double>(), It.Is<double>(v => v == motorWidth)), Times.Once);
        }
    }
}