using Xunit;

namespace JustOneProject.StyleCop
{
    public class RewriteRulesetTests
    {
        [Fact]
        public static void Test()
        {
            var sut = new RewriteRuleset();

            sut.Do("StyleCop/Files/Release.ruleset", "StyleCop/Files/Debug.ruleset", "output.xml");
        }
    }
}