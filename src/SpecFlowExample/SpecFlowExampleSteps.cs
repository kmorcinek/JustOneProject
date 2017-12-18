using FluentAssertions;
using KMorcinek.SpecFlowExample.Extensions;
using TechTalk.SpecFlow;

namespace KMorcinek.SpecFlowExample
{
    [Binding]
    public class SpecFlowExampleSteps
    {
        readonly ScenarioContext _context;

        public SpecFlowExampleSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"Please purchase at http://www\.specflow\.org/plus to remove this scenario\.")]
        public void GivenPleasePurchaseAtHttpWww_Specflow_OrgPlusToRemoveThisScenario_()
        {
            var fluxDensity = _context.GetEx(CommonInputSteps.FluxDensity);

            var coreDiameter = _context.GetEx(CommonInputSteps.CoreDiamater);
        }
        
        [When(@"I calculate multiplication")]
        public void WhenICalculateMultiplication()
        {
            int input = _context.GetEx(CommonInputSteps.InputValueInKey);

            int result = input * 2;

            _context.SetEx(CommonOutputSteps.ResultOutKey, result);
        }
    }
}
