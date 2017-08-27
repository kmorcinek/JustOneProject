using FluentAssertions;
using KMorcinek.SpecFlowExample.Extensions;
using TechTalk.SpecFlow;

namespace KMorcinek.SpecFlowExample
{
    [Binding]
    public class AdditionTestsSteps
    {
        readonly ScenarioContext _context;

        public AdditionTestsSteps(ScenarioContext context)
        {
            _context = context;
        }

        [When(@"I calculate addition")]
        public void WhenICalculateAddition()
        {
            int input = _context.GetEx(CommonInputSteps.InputValueInKey);

            int result = input + 7;

            _context.SetEx(CommonOutputSteps.ResultOutKey, result);
        }
    }
}
