using OpenQA.Selenium;

namespace TestProject2.Locators
{
    public static class CartPageLocators
    {
        public static readonly By CartProduct =
            By.XPath("//tr[contains(@id,'product')]");

        public static readonly By ProceedToCheckout =
            By.XPath("//a[contains(text(),'Proceed To Checkout')]");
    }
}
