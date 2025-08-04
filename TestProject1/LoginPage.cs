using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestProject1.Pages;

namespace TestProject1
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        private readonly By usernameField = By.Id("username");
        private readonly By passwordField = By.Id("password");
        private readonly By submitButton = By.Id("submit");
        private readonly By errorMessage = By.Id("error");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public LoginPage EnterUsername(string username)
        {
            _driver.FindElement(usernameField).Clear();
            _driver.FindElement(usernameField).SendKeys(username);
            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            _driver.FindElement(passwordField).Clear();
            _driver.FindElement(passwordField).SendKeys(password);
            return this;
        }

        public SecureAreaPage ClickLoginSuccess()
        {
            _driver.FindElement(submitButton).Click();
            return new SecureAreaPage(_driver);
        }

        public LoginPage ClickLoginExpectingFailure()
        {
            _driver.FindElement(submitButton).Click();
            return this;
        }

        public string GetErrorMessage()
        {
            return _driver.FindElement(errorMessage).Text;
        }

        public bool IsErrorMessageDisplayed()
        {
            return _driver.FindElement(errorMessage).Displayed;
        }
    }
}