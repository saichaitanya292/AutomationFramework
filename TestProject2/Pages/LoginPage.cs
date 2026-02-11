using OpenQA.Selenium;
using TestProject2.Constants;
using TestProject2.Locators;

namespace TestProject2.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        public void Navigate()
        {
            _driver.Navigate().GoToUrl(UrlConstants.LoginUrl);
        }

        public void Login(string email, string password)
        {
            Type(LoginPageLocators.Email, email);
            Type(LoginPageLocators.Password, password);
            Click(LoginPageLocators.LoginButton);
        }

        public bool IsLoginSuccessful()
        {
            return IsElementDisplayed(LoginPageLocators.LoggedInUser);
        }
    }
}
