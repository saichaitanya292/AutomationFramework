using OpenQA.Selenium;
using TestProject2.Constants;
using TestProject2.Locators;

namespace TestProject2.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToProducts()
        {
            _driver.Navigate().GoToUrl(UrlConstants.ProductsUrl);
        }

        public void SearchProduct(string productName)
        {
            NavigateToProducts();

            Type(HomePageLocators.SearchInput, productName);
            Click(HomePageLocators.SearchButton);
        }

        public void AddFirstProductToCart()
        {
            Click(HomePageLocators.FirstProductAddToCart);
            Click(HomePageLocators.ContinueShoppingButton);
        }

        public void GoToCart()
        {
            Click(HomePageLocators.CartMenu);
        }
    }
}
