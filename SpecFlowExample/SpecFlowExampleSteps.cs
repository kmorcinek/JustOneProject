using FluentAssertions;
using TechTalk.SpecFlow;

namespace KMorcinek.SpecFlowExample
{
    [Binding]
    public class SpecFlowExampleSteps
    {
        public const string InputValueInKey = "inputValueIn";
        public const string ResultOutKey = "resultOut";
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
        
        [Given(@"Use (.*) as a input value")]
        public void GivenUseAsAInputValue(int p0)
        {
            _context.Set(p0, InputValueInKey);
        }
        
        [When(@"I calculate multiplication")]
        public void WhenICalculateMultiplication()
        {
            int input = _context.Get<int>(InputValueInKey);
            int result = input * 2;
            _context.Set(result, ResultOutKey);
        }
        
        [Then(@"Output Multiplication is (.*)")]
        public void ThenOutputMultiplicationIs(int p0)
        {
            _context.Get<int>(ResultOutKey).Should().Be(p0)
        }
    }
}
