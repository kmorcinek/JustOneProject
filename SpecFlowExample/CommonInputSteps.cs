using TechTalk.SpecFlow;

namespace KMorcinek.SpecFlowExample
{
    [Binding]
    public class CommonInputSteps
    {
        public const string InputValueInKey = "inputValueIn";

        readonly ScenarioContext _context;

        public CommonInputSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"Use (.*) as a input value")]
        public void GivenUseAsAInputValue(int p0)
        {
            _context.Set(p0, InputValueInKey);
        }
    }
}