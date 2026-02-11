using OpenQA.Selenium;

namespace TestProject2.Utilities
{
    public static class ScreenshotHelper
    {
        public static string CaptureScreenshot(IWebDriver driver, string name)
        {
            var folderPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "TestResults",
                "Screenshots");

            Directory.CreateDirectory(folderPath);

            var filePath = Path.Combine(
                folderPath,
                $"{name}_{DateTime.Now:yyyyMMdd_HHmmss}.png");

            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(filePath);

            return filePath;   
        }
    }
}
