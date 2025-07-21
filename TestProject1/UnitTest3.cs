using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestProject1.Pages;

namespace TestProject1
{
    public class Tests3
    {
        WebDriver driver;

        [SetUp]
        public void setUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
        }

        [TearDown]
        public void tearDown()
        {
            driver.Quit();
        }

        [Test]
        public void PositiveLogin1()
        {
            driver.FindElement(By.Id("username")).SendKeys("student");
            driver.FindElement(By.Id("password")).SendKeys("Password123");
            driver.FindElement(By.Id("submit")).Click();

            string CurrentURL = driver.Url;

            // How to string assert 
            StringAssert.Contains("https://practicetestautomation.com/logged-in-successfully/", CurrentURL);

            //// How to check text content
            string bodyText = driver.FindElement(By.TagName("body")).Text.ToLower();
            Console.WriteLine(bodyText);
            Assert.IsTrue(bodyText.Contains("logged in successfully") || bodyText.Contains("congratulations student. you successfully logged in!"));

            //// How to check if log out button is displayed
            Assert.IsTrue(driver.FindElement(By.XPath("//a[text()='Log out']")).Displayed);

        }

        [Test]
        public void negativeUsername1()
        {
            driver.FindElement(By.Id("username")).SendKeys("incorrectUser");
            driver.FindElement(By.Id("password")).SendKeys("Password123");
            driver.FindElement(By.Id("submit")).Click();

            IWebElement errorMsg = driver.FindElement(By.Id("error"));

            Console.WriteLine(errorMsg.Text);
            //Assert.IsTrue(errorMsg.Displayed);
            //Assert.That(errorMsg.Text, Is.EqualTo("Your username is invalid!"));
        }

        [Test]
        public void negativePW1()
        {
            driver.FindElement(By.Id("username")).SendKeys("student");
            driver.FindElement(By.Id("password")).SendKeys("incorrectPassword");
            driver.FindElement(By.Id("submit")).Click();
            //
            IWebElement errorMsg = driver.FindElement(By.Id("error"));
            Assert.IsTrue(errorMsg.Displayed);
            Assert.That(errorMsg.Text, Is.EqualTo("Your password is invalid!"));
        }
    
    }
}