using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestProject1.Pages;

namespace TestProject1
{
    public class SecureAreaPage
    {
        private readonly IWebDriver _driver;

        private readonly By successMessage = By.ClassName("post-title");
        private readonly By logoutButton = By.XPath("//a[text()='Log out']");

        public SecureAreaPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetSuccessMessage()
        {
            return _driver.FindElement(successMessage).Text;
        }

        public bool IsLogoutButtonVisible()
        {
            return _driver.FindElement(logoutButton).Displayed;
        }
    }
}