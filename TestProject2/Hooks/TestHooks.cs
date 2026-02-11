using System;
using System.IO;
using OpenQA.Selenium;
using Reqnroll;
using TestProject2.Reporting;
using TestProject2.Utilities;

namespace TestProject2.Hooks
{
    [Binding]
    public class TestHooks
    {
        private readonly ScenarioContext _scenarioContext;

        public TestHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [BeforeScenario]
        public void BeforeScenario()
        {
            var scenarioName = _scenarioContext.ScenarioInfo.Title;

            ExtentManager.CreateTest(scenarioName);
        }


        [AfterStep]
        public void AfterEachStep()
        {
            if (!_scenarioContext.ContainsKey("Driver"))
                return;

            var driver = (IWebDriver)_scenarioContext["Driver"];

            var stepInfo = _scenarioContext.StepContext.StepInfo;
            var stepText = stepInfo.Text;
            var stepType = stepInfo.StepDefinitionType.ToString();

      
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                stepText = stepText.Replace(c.ToString(), "");
            }

            stepText = stepText.Replace(" ", "_");

          
            if (stepText.Length > 60)
                stepText = stepText.Substring(0, 60);

            
            var screenshotPath = ScreenshotHelper
                .CaptureScreenshot(driver, stepText);

            var test = ExtentManager.GetTest();

            if (_scenarioContext.TestError == null)
            {
                test?
                    .Info($"{stepType}: {stepInfo.Text}")
                    .AddScreenCaptureFromPath(screenshotPath);
            }
            else
            {
                test?
                    .Fail($"{stepType}: {stepInfo.Text}")
                    .AddScreenCaptureFromPath(screenshotPath);
            }
        }


        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentManager.FlushReport();
        }
    }
}
