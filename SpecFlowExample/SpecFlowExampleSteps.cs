using FluentAssertions;
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
            //ScenarioContext.Current.Pending();
        }
        
        [When(@"I calculate multiplication")]
        public void WhenICalculateMultiplication()
        {
            int input = _context.Get<int>(CommonInputSteps.InputValueInKey);

            int result = input * 2;

            _context.Set(result, CommonOutputSteps.ResultOutKey);
        }
    }
}
