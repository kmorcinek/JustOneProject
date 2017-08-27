using TechTalk.SpecFlow;

namespace KMorcinek.SpecFlowExample.Extensions
{
    public static class ContextScenarionExtensions
    {
        public static T Get<T>(this ScenarioContext scenarioContext, NameWithType<T> nameWithType)
        {
            return scenarioContext.Get<T>(nameWithType.Name);
        }

        public static void Set<T>(this ScenarioContext scenarioContext, NameWithType<T> nameWithType, T value)
        {
            scenarioContext.Set(value, nameWithType.Name);
        }
    }
}