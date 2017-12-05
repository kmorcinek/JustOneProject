using KMorcinek.SpecFlowExample.Extensions;
using TechTalk.SpecFlow;

namespace KMorcinek.SpecFlowExample
{
    [Binding]
    public class CommonInputSteps
    {
        public static readonly NameWithType<int> InputValueInKey = new NameWithType<int>("inputValueIn");

        readonly ScenarioContext _context;

        public CommonInputSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"Use (.*) as a input value")]
        public void GivenUseAsAInputValue(int p0)
        {
            _context.SetEx(InputValueInKey, p0);
        }
    }
}