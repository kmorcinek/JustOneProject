using TechTalk.SpecFlow;

namespace KMorcinek.SpecFlowExample.Extensions
{
    public static class ScenarioContextExtensions
    {
        public static T GetEx<T>(this ScenarioContext scenarioContext, NameWithType<T> nameWithType)
        {
            return scenarioContext.Get<T>(nameWithType.Name);
        }

        public static void SetEx<T>(this ScenarioContext scenarioContext, NameWithType<T> nameWithType, T value)
        {
            scenarioContext.Set(value, nameWithType.Name);
        }
    }
}