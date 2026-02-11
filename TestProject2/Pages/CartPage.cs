using OpenQA.Selenium;

namespace TestProject2.Pages
{
    public class CartPage : BasePage
    {

        public CartPage(IWebDriver driver) : base(driver)
        {
       
        }

        private IWebElement ProceedToCheckout =>
            _driver.FindElement(By.XPath("//a[contains(text(),'Proceed To Checkout')]"));

        public void Checkout()
        {
            ProceedToCheckout.Click();
        }

        public bool IsProductAdded()
        {
            return _driver.FindElements(By.XPath("//tr[@id='product-1']")).Count > 0;
        }

        public void ProceedToCheckoutNow()
        {
            _driver.FindElement(By.XPath("//a[contains(text(),'Proceed To Checkout')]")).Click();
            GuardAgainstAds();
        }

    }
}
