using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestProject1
{
    public class Tests2
    {
        WebDriver driver;
        WebDriverWait wait;
        [Test]
        public void Testcase2()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.dummyticket.com/dummy-ticket-for-visa-application/");

            Application();
          

        }
        public void Application()
        {
            driver.FindElement(By.Name("travname")).SendKeys("Nada");
            driver.FindElement(By.Name("travlastname")).SendKeys("Nasr");
            driver.FindElement(By.Id("dob")).Click();

            // how to select date from date picker??

            driver.FindElement(By.CssSelector(".ui-datepicker-year")).Click();
            driver.FindElement(By.XPath("//option[text()='2001']")).Click();
            driver.FindElement(By.CssSelector(".ui-datepicker-month")).Click();
            driver.FindElement(By.XPath("//option[text()='Dec']")).Click();
            driver.FindElement(By.XPath("//a[text()='8']")).Click();

            // how to select radio button and checkbox?

            driver.FindElement(By.Id("sex_2")).Click();
            driver.FindElement(By.Id("traveltype_2")).Click();

            driver.FindElement(By.Id("fromcity")).SendKeys("New York");
            driver.FindElement(By.Id("tocity")).SendKeys("Cairo");
            driver.FindElement(By.Id("departon")).Click();

            driver.FindElement(By.CssSelector(".ui-datepicker-year")).Click();
            driver.FindElement(By.XPath("//option[text()='2025']")).Click();
            driver.FindElement(By.CssSelector(".ui-datepicker-month")).Click();
            driver.FindElement(By.XPath("//option[text()='Aug']")).Click();
            driver.FindElement(By.XPath("//a[text()='12']")).Click();

            driver.FindElement(By.Id("returndate")).Click();
            driver.FindElement(By.CssSelector(".ui-datepicker-year")).Click();
            driver.FindElement(By.XPath("//option[text()='2025']")).Click();
            driver.FindElement(By.CssSelector(".ui-datepicker-month")).Click();
            driver.FindElement(By.XPath("//option[text()='Aug']")).Click();
            driver.FindElement(By.XPath("//a[text()='20']")).Click();

            driver.FindElement(By.Id("billing_phone")).SendKeys("01225838557");
            driver.FindElement(By.Id("billing_email")).SendKeys("nada2001nasr@gmail.com");
            new SelectElement(driver.FindElement(By.CssSelector("select#billing_country"))).SelectByText("Egypt");
            driver.FindElement(By.Id("billing_address_1")).SendKeys("Cairo, Egypt");
            driver.FindElement(By.Id("billing_address_2")).SendKeys("New Cairo");
            driver.FindElement(By.Id("billing_city")).SendKeys("Rehab City");
            new SelectElement(driver.FindElement(By.CssSelector("select#billing_state"))).SelectByText("Cairo");
            driver.FindElement(By.Id("billing_postcode")).SendKeys("11845");


            //how to move to a frame on the page 
            // visa test card details
            driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("iframe[name^='__privateStripeFrame']")));
            driver.FindElement(By.CssSelector("input#Field-numberInput")).SendKeys("4242424242424242");
            driver.FindElement(By.CssSelector("input#Field-expiryInput")).SendKeys("12/30");
            driver.FindElement(By.CssSelector("input#Field-cvcInput")).SendKeys("123");
            driver.SwitchTo().DefaultContent();
            driver.FindElement(By.Id("place_order")).Click();

            driver.Quit();

        }
        [Test]
        public void fileUpload()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://aa-practice-test-automation.vercel.app/Pages/uploadFile.html");

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            // Ensure file exists
            string filePath = @"C:\Users\Nadaa.Nasr\Pictures\Screenshots\English.png";
            if (!System.IO.File.Exists(filePath))
                throw new Exception("File not found!");

            IWebElement fileInput = wait.Until(drv => drv.FindElement(By.CssSelector("input#regularFileInput")));

            fileInput.SendKeys(filePath);

            Thread.Sleep(5000);

            driver.Quit();
        }

        [Test]
        public void buttonFinder()
        {
            WebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/add_remove_elements/");

            IWebElement addButton = driver.FindElement(By.XPath("//button[text()='Add Element']"));
            Console.WriteLine("Tag Name: " + addButton.TagName);
            Console.WriteLine("Attribute: " + addButton.GetAttribute("example"));

            Size size = addButton.Size;
            Console.WriteLine("Width: " + size.Width + "," + "Height: " + size.Height);

            Point location = addButton.Location;
            Console.WriteLine("X: " + location.X + "," + "Y: " + location.Y);
            Console.WriteLine("Is Enabled: " + addButton.Enabled);
            driver.Quit();
        }

        [Test]
        public void Checkbox()
        {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://aa-practice-test-automation.vercel.app/Pages/checkbox_Radio.html");

            //how to check wheather the checkbox is selected or not?
            IWebElement checkbox = driver.FindElement(By.Id("Ahly"));
            if (!checkbox.Selected)
            {
                checkbox.Click();
            }
            else
            {
                Console.WriteLine("Checkbox is already selected.");
            }
            driver.Quit();
        }
        [Test]
        public void shadowDOM()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://books-pwakit.appspot.com/");



            // Accessing Shadow DOM elements
             driver.FindElement(By.CssSelector("[apptitle='BOOKS']"))
                .GetShadowRoot()
                .FindElement(By.CssSelector("[id='input']"))
                .SendKeys("Test");

   
            driver.Quit();
        }

        [Test]
        public void Synchronizations()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/2");
            driver.FindElement(By.TagName("button")).Click();

            // Explicit Wait
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(drv => drv.FindElement(By.CssSelector("#finish h4")).Displayed);
            string text = driver.FindElement(By.CssSelector("#finish h4")).Text;
            Console.WriteLine("Test: " + text);

            driver.Quit();
        }

        [Test]
        public void handelingWindows()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");

            driver.FindElement(By.LinkText("Click Here")).Click();

            IWebElement results = driver.FindElement(By.TagName("h3"));

            string actualResults = results.Text;
            string expectedResults = "Opening a new window";
            if (actualResults == expectedResults)
            {
                Console.WriteLine("Test Passed");
            }
            else
            {
                Console.WriteLine("Test Failed");
            }

            Console.WriteLine("Results: " + actualResults);

            // Switch to the previous window
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            driver.Quit();
        }

        [Test]
        public void Frames()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/iframe");

            // how to find a frame on the page

            // Switch to the frame using its ID
            driver.SwitchTo().Frame("mce_0_ifr");
            // Perform actions within the frame
            IWebElement contentArea = driver.FindElement(By.Id("mce_0"));

        }

    }
    }