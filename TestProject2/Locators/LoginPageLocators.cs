using OpenQA.Selenium;

namespace TestProject2.Locators
{
    public static class LoginPageLocators
    {
        public static readonly By Email = By.Name("email");
        public static readonly By Password = By.Name("password");
        public static readonly By LoginButton =
            By.XPath("//button[text()='Login']");
        public static readonly By LoggedInUser =
            By.XPath("//a[contains(text(),'Logged in as')]");
    }
}
