using OpenQA.Selenium;

namespace TestProject1.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        private readonly By usernameField = By.Id("username");
        private readonly By passwordField = By.Id("password");
        private readonly By submitButton = By.Id("submit");
        private readonly By errorMessage = By.Id("error");
        private readonly By logoutButton = By.XPath("//a[text()='Log out']");
        private readonly By bodyTag = By.TagName("body");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public LoginPage EnterUsername(string username)
        {
            driver.FindElement(usernameField).Clear();
            driver.FindElement(usernameField).SendKeys(username);
            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            driver.FindElement(passwordField).Clear();
            driver.FindElement(passwordField).SendKeys(password);
            return this;
        }

        public LoginPage ClickSubmit()
        {
            driver.FindElement(submitButton).Click();
            return this;
        }

        public string GetUrl() => driver.Url;

        public string GetBodyText() => driver.FindElement(bodyTag).Text;

        public bool IsLogoutVisible() => driver.FindElement(logoutButton).Displayed;

        public string GetErrorMessage() => driver.FindElement(errorMessage).Text;

        public bool IsErrorDisplayed() => driver.FindElement(errorMessage).Displayed;
    }
}
