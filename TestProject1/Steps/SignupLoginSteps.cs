using Automation.Common.Models;
using Automation.Common.Services;
using FluentAssertions;
using Microsoft.Playwright;
using TestProject1.Pages;
using TestProject1.Reporting;
using Reqnroll;
using System.Linq;

namespace TestProject1.Steps
{
    [Binding]
    public class SignupLoginSteps
    {
        private readonly IPage _page;
        private readonly LoginSignupPage _loginPage;
        private readonly AccountRegistrationPage _registrationPage;

        private UserModel _user = null!;

        public SignupLoginSteps(ScenarioContext scenarioContext)
        {
            _page = (IPage)scenarioContext["Page"];
            _loginPage = new LoginSignupPage(_page);
            _registrationPage = new AccountRegistrationPage(_page);
        }

        [Given(@"User navigates to signup page")]
        public async Task GivenUserNavigatesToSignupPage()
        {
            ExtentManager.GetTest()?.Info("Navigating to signup page");
            await _loginPage.Navigate();
        }

        [When(@"User enters name and email")]
        public async Task WhenUserEntersNameAndEmail()
        {
    
            _user = new UserModel
            {
                FirstName = $"User{Guid.NewGuid():N}".Substring(0, 8),
                LastName = "Automation",
                Email = $"test{Guid.NewGuid():N}@mail.com",
                Password = "Test@123",
                Address = "Hyderabad",
                State = "Telangana",
                City = "Hyderabad",
                ZipCode = "500001",
                Mobile = "9876543210"
            };

         
            UserDataManager.SaveUser(_user);

            ExtentManager.GetTest()?.Info($"Generated User: {_user.FirstName}");
            ExtentManager.GetTest()?.Info($"Email: {_user.Email}");

            await _loginPage.EnterSignupDetails(_user.FirstName, _user.Email);
        }

        [When(@"User completes account registration")]
        public async Task WhenUserCompletesRegistration()
        {
            ExtentManager.GetTest()?.Info("Completing account registration");

            await _registrationPage.CompleteRegistration(
                _user.Password,
                _user.FirstName,
                _user.LastName,
                _user.Address,
                _user.State,
                _user.City,
                _user.ZipCode,
                _user.Mobile);
        }

        [Then(@"User should be logged in successfully")]
        public async Task ThenUserShouldBeLoggedInSuccessfully()
        {
            ExtentManager.GetTest()?.Info("Verifying user login status");

            var links = await _registrationPage.GetAllLinks();

            var isLoggedIn = links.Any(text => text.Contains("Logged in as"));

            isLoggedIn.Should().BeTrue("user should be logged in successfully");

            ExtentManager.GetTest()?.Pass("User logged in successfully");
        }
    }
}
