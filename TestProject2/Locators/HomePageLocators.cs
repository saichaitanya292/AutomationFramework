using OpenQA.Selenium;

namespace TestProject2.Locators
{
    public static class HomePageLocators
    {
        public static By ProductsMenu = By.XPath("//a[@href='/products']");
        public static By SearchInput = By.Id("search_product");
        public static By SearchButton = By.Id("submit_search");
        public static By FirstProductAddToCart = By.XPath("(//a[contains(text(),'Add to cart')])[1]");
        public static By ContinueShoppingButton = By.XPath("//button[text()='Continue Shopping']");
        public static By CartMenu = By.XPath("//a[contains(text(),'Cart')]");
    }
}
