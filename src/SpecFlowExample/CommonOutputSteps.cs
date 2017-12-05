using FluentAssertions;
using KMorcinek.SpecFlowExample.Extensions;
using TechTalk.SpecFlow;

namespace KMorcinek.SpecFlowExample
{
    [Binding]
    public class CommonOutputSteps
    {
        public static readonly NameWithType<int> ResultOutKey = new NameWithType<int>("resultOut");

        readonly ScenarioContext _context;

        public CommonOutputSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Then(@"Result is (.*)")]
        public void ThenResultIs(int result)
        {
            _context.GetEx(ResultOutKey).Should().Be(result);
        }
    }
}