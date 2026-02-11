using Reqnroll;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Automation.Common.Services;
using Automation.Common.Models;
using TestProject2.Pages;
using TestProject2.Utilities;

namespace TestProject2.PurchaseFlowSteps
{
    [Binding]
    public class PurchaseFlowSteps
    {
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver _driver = null!;
        private UserModel _user = null!;

        private LoginPage _loginPage = null!;
        private HomePage _homePage = null!;
        private CartPage _cartPage = null!;
        private CheckoutPage _checkoutPage = null!;

        public PurchaseFlowSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void Setup()
        {
            Logger.Info("Starting browser...");

            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            _driver = new ChromeDriver(options);

            _scenarioContext["Driver"] = _driver;

            _user = UserDataManager.GetUser();

            _loginPage = new LoginPage(_driver);
            _homePage = new HomePage(_driver);
            _cartPage = new CartPage(_driver);
            _checkoutPage = new CheckoutPage(_driver);
        }

        //////////////////////////////////////////////////////
        // LOGIN STEPS
        //////////////////////////////////////////////////////

        [Given(@"User navigates to login page")]
        public void GivenUserNavigatesToLoginPage()
        {
            Logger.Info("Navigating to login page");
            _loginPage.Navigate();
        }

        [When(@"User logs in with generated credentials")]
        public void WhenUserLogsInWithGeneratedCredentials()
        {
            Logger.Info("Logging in with generated user");
            _loginPage.Login(_user.Email, _user.Password);
        }

        [When(@"User enters payment details")]
        public void WhenUserEntersPaymentDetails()
        {
            _checkoutPage.EnterPaymentDetails();
        }


        [Then(@"Login should be successful")]
        public void ThenLoginShouldBeSuccessful()
        {
            Logger.Info("Validating login success");

            Assert.That(_loginPage.IsLoginSuccessful(),
                Is.True,
                "Login validation failed.");
        }

        //////////////////////////////////////////////////////
        // PRODUCT STEPS
        //////////////////////////////////////////////////////

        [When(@"User searches for product ""(.*)""")]
        public void WhenUserSearchesForProduct(string productName)
        {
            Logger.Info($"Searching product: {productName}");
            _homePage.SearchProduct(productName);
        }

        [When(@"User adds first product to cart")]
        public void WhenUserAddsFirstProductToCart()
        {
            Logger.Info("Adding first product to cart");
            _homePage.AddFirstProductToCart();
        }

        [When(@"User navigates to cart")]
        public void WhenUserNavigatesToCart()
        {
            Logger.Info("Navigating to cart page");
            _homePage.GoToCart();
        }

        [Then(@"Product should be added to cart")]
        public void ThenProductShouldBeAddedToCart()
        {
            Logger.Info("Validating product in cart");

            Assert.That(_cartPage.IsProductAdded(),
                Is.True,
                "Product was not added to cart.");
        }

        //////////////////////////////////////////////////////
        // CHECKOUT STEPS
        //////////////////////////////////////////////////////

        [When(@"User proceeds to checkout")]
        public void WhenUserProceedsToCheckout()
        {
            Logger.Info("Proceeding to checkout");
            _cartPage.ProceedToCheckoutNow();
        }

        [When(@"User places the order")]
        public void WhenUserPlacesTheOrder()
        {
            Logger.Info("Placing order");
            _checkoutPage.PlaceOrderNow();
        }

        [When(@"User navigates to products page")]
        public void WhenUserNavigatesToProductsPage()
        {
            Logger.Info("Navigating to products page");
            _homePage.NavigateToProducts();
        }

        [Then(@"Order should be placed successfully")]
        public void ThenOrderShouldBePlacedSuccessfully()
        {
            Logger.Info("Validating order placement");

            Assert.That(_checkoutPage.IsOrderPlaced(),
                Is.True,
                "Order placement failed.");
        }

        //////////////////////////////////////////////////////
        // TEARDOWN
        //////////////////////////////////////////////////////

        [AfterScenario]
        public void TearDown()
        {
            Logger.Info("Closing browser");

            _driver.Quit();
            _driver.Dispose();
        }
    }
}
