using TechTalk.SpecFlow;

namespace KMorcinek.SpecFlowExample
{
    [Binding]
    public class SpecFlowExampleSteps
    {
        [Given(@"Please purchase at http://www\.specflow\.org/plus to remove this scenario\.")]
        public void GivenPleasePurchaseAtHttpWww_Specflow_OrgPlusToRemoveThisScenario_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Use (.*) as a input value")]
        public void GivenUseAsAInputValue(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I calculate multiplication")]
        public void WhenICalculateMultiplication()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Output Multiplication is (.*)")]
        public void ThenOutputMultiplicationIs(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
