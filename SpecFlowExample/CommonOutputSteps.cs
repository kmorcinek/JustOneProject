using FluentAssertions;
using TechTalk.SpecFlow;

namespace KMorcinek.SpecFlowExample
{
    [Binding]
    public class CommonOutputSteps
    {
        public const string ResultOutKey = "resultOut";

        readonly ScenarioContext _context;

        public CommonOutputSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Then(@"Result is (.*)")]
        public void ThenResultIs(int result)
        {
            _context.Get<int>(ResultOutKey).Should().Be(result);
        }
    }
}