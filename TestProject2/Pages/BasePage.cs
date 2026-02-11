using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace TestProject2.Pages
{

    public class BasePage
    {
        protected readonly IWebDriver _driver;
        protected readonly WebDriverWait _wait;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        protected void GuardAgainstAds()
        {
            try
            {
               
                if (_driver.Url.Contains("google_vignette"))
                {
                    _driver.Navigate().Back();
                }

                
                ((IJavaScriptExecutor)_driver).ExecuteScript(@"
            document.querySelectorAll('iframe').forEach(el => el.remove());
            document.querySelectorAll('[id*=google]').forEach(el => el.remove());
        ");
            }
            catch { }
        }

        protected void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", element);
        }

        protected void Click(By locator)
        {
            GuardAgainstAds();  

            var element = _wait.Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions
                .ElementToBeClickable(locator));

            ScrollToElement(element);

            element.Click();
        }



        protected void Type(By locator, string text)
        {
            var element = _wait.Until(ExpectedConditions.ElementIsVisible(locator));
            element.Clear();
            element.SendKeys(text);
        }

        protected bool IsElementDisplayed(By locator)
        {
            try
            {
                return _driver.FindElement(locator).Displayed;
            }
            catch
            {
                return false;
            }
        }

        protected void RemoveAds()
        {
            try
            {
                var js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript(@"
            var ads = document.querySelectorAll('iframe[id^=""aswift_""]');
            ads.forEach(ad => ad.remove());
        ");
            }
            catch
            {
                // Ignore errors
            }
        }


    }
}
