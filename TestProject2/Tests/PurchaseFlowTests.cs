using NUnit.Framework;
using OpenQA.Selenium;
using TestProject2.Drivers;
using TestProject2.Pages;
using Automation.Common.Models;
using Automation.Common.Services;

namespace TestProject2.Tests
{
    public class PurchaseFlowTests
    {
        private IWebDriver? _driver;
        private UserModel _user = null!;

        private LoginPage? _loginPage;
        private HomePage? _homePage;
        private CartPage? _cartPage;

        [SetUp]
        public void Setup()
        {
            _driver = DriverFactory.CreateDriver();

            _loginPage = new LoginPage(_driver);
            _homePage = new HomePage(_driver);
            _cartPage = new CartPage(_driver);

         
            _user = UserDataManager.GetUser();
        }

        [Test]
        public void LoginAndPurchaseFlow()
        {
            _loginPage!.Navigate();
            _loginPage.Login(_user.Email, _user.Password);

            _homePage!.AddFirstProductToCart();
            _homePage.GoToCart();

            _cartPage!.Checkout();

            Assert.Pass("Purchase flow executed successfully");
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}
