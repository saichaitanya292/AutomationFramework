using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject2.Drivers
{
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            var options = new ChromeOptions();

            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--disable-infobars");
            options.AddArgument("--disable-extensions");

         
            options.AddArgument("--disable-features=OverlayScrollbar,InterestFeedContentSuggestions");
            options.AddArgument("--disable-background-networking");
            options.AddArgument("--disable-sync");

            return new ChromeDriver(options);
        }
    }
}
