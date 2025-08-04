using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestProject1.Pages;

namespace TestProject1
{
    public class UnitTest5
    {
        private IWebDriver driver;
        private const string LoginUrl = "https://practicetestautomation.com/practice-test-login/";

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(LoginUrl);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void PositiveLoginTest()
        {
            var loginPage = new LoginPage(driver);
            var securePage = loginPage
                .EnterUsername("student")
                .EnterPassword("Password123")
                .ClickLoginSuccess();

            Assert.That(driver.Url, Does.Contain("practicetestautomation.com/logged-in-successfully/"));

            string message = securePage.GetSuccessMessage().ToLower();
            Assert.IsTrue(message.Contains("congratulations") || message.Contains("successfully logged in"));

            Assert.IsTrue(securePage.IsLogoutButtonVisible(), "Logout button should be visible");
        }

        [Test]
        public void NegativeUsernameTest()
        {
            var loginPage = new LoginPage(driver);
            loginPage
                .EnterUsername("incorrectUser")
                .EnterPassword("Password123")
                .ClickLoginExpectingFailure();

            Assert.IsTrue(loginPage.IsErrorMessageDisplayed(), "Error message should be displayed");
            Assert.That(loginPage.GetErrorMessage(), Is.EqualTo("Your username is invalid!"));
        }

        [Test]
        public void NegativePasswordTest()
        {
            var loginPage = new LoginPage(driver);
            loginPage
                .EnterUsername("student")
                .EnterPassword("incorrectPassword")
                .ClickLoginExpectingFailure();

            Assert.IsTrue(loginPage.IsErrorMessageDisplayed(), "Error message should be displayed");
            Assert.That(loginPage.GetErrorMessage(), Is.EqualTo("Your password is invalid!"));
        }
    }
}