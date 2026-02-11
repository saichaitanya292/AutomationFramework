using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestProject2.Utilities
{
    public static class WaitHelper
    {
        public static IWebElement WaitForElement(
            IWebDriver driver, By locator, int seconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(d =>
            {
                var element = d.FindElement(locator);
                return element.Displayed ? element : null;
            });
        }
    }
}
