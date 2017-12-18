using KMorcinek.SpecFlowExample.Extensions;
using TechTalk.SpecFlow;

namespace KMorcinek.SpecFlowExample
{
    [Binding]
    public class CommonInputSteps
    {
        public static readonly NameWithType<int> InputValueInKey = new NameWithType<int>("inputValueIn");
        public static readonly NameWithType<Tesla> FluxDensity = new NameWithType<Tesla>(nameof(FluxDensity) + "In");
        public static readonly NameWithType<Millimetre> CoreDiamater = new NameWithType<Millimetre>(nameof(CoreDiamater) + "In");

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