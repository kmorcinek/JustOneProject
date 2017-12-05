namespace JustOneProject.VariousStuff.CodeReviews.RefactorTestToAutoFixture
{
    public class AreaCalculationEngine
    {
        readonly ILengthEngine _lengthEngine;

        public AreaCalculationEngine(ILengthEngine lengthEngine)
        {
            _lengthEngine = lengthEngine;
        }

        public double CalculateArea(double motorWidth, double width, double distance)
        {
            double length = _lengthEngine.CalculateLength(distance, width);

            return length * motorWidth;
        }
    }
}