using OpenQA.Selenium;

namespace TestProject2.Locators
{
    public static class CheckoutPageLocators
    {
        public static By PlaceOrderButton =
            By.XPath("//a[contains(text(),'Place Order')]");

        public static By OrderPlacedMessage =
            By.XPath("//b[contains(text(),'Order Placed!')]");
    }
}
