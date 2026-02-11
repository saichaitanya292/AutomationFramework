using OpenQA.Selenium;
using TestProject2.Locators;

namespace TestProject2.Pages
{
    public class CheckoutPage : BasePage
    {

        public CheckoutPage(IWebDriver driver) : base(driver) {
  
            
        }

        public void PlaceOrderNow()
        {
            _driver.FindElement(CheckoutPageLocators.PlaceOrderButton).Click();
        }

        public void EnterPaymentDetails()
        {
            Type(By.Name("name_on_card"), "Test User");
            Type(By.Name("card_number"), "4111111111111111");
            Type(By.Name("cvc"), "123");
            Type(By.Name("expiry_month"), "12");
            Type(By.Name("expiry_year"), "2028");

            Click(By.Id("submit"));
        }

        public bool IsOrderPlaced()
        {
            return _driver.FindElements(
                CheckoutPageLocators.OrderPlacedMessage
            ).Count > 0;
        }
    }
}
