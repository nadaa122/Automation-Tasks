using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject1
{
    public class Tests
    {
       WebDriver driver;
        [Test]
        public void Testcase()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://example.com/");
            
            string PageURL = driver.Url;
            Console.WriteLine("Page URL: " + PageURL);

            string HTML = driver.PageSource;
            Console.WriteLine("Page HTML: " + HTML);


            string PageTittle = driver.Title;
            Console.WriteLine("Page Tittle: " + PageTittle);

            String currentBrowserID = driver.CurrentWindowHandle;
            Console.WriteLine("Current Page ID: " + currentBrowserID);

            driver.Navigate().GoToUrl("https://selenium.dev/");

            driver.Navigate().Back();
            driver.Navigate().Forward();
            driver.Navigate().Refresh();
            driver.Navigate().Back();

            Size windowSize = driver.Manage().Window.Size;
            Console.WriteLine("Window Size: " + windowSize);

            Point windowPosition = driver.Manage().Window.Position;
            Console.WriteLine("Window Position: " + windowPosition);

            driver.Manage().Window.Size = new Size(1024, 768);
            driver.Manage().Window.Position= new Point(200, 150);

            driver.Manage().Window.Maximize();
            driver.Manage().Window.FullScreen();

            driver.Close();


            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://example.com/");
            driver.Quit();
        }

        
        [Test]
        public void test2()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.facebook.com/r.php?entry_point=login");
            //locate fields by id, name, className, tagName, xpath, and cssSelector. Fill in test data.
            IWebElement firstNameField = driver.FindElement(By.Id("u_0_m"));
            firstNameField.SendKeys("John");
            IWebElement lastNameField = driver.FindElement(By.Id("u_0_o"));
            lastNameField.SendKeys("Doe");
            IWebElement emailField = driver.FindElement(By.Id("u_0_r"));
            
        } 
    } 
}