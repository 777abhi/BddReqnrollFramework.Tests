using Reqnroll;

namespace BddReqnrollFramework.Tests.Hooks
{
    [Binding]
    public class SetupHooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Starting test run");
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            
            Console.WriteLine($"Starting scenario: {scenarioContext.ScenarioInfo.Title}");
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Scenario completed");
        }
    }
}