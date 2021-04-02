using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestUI
{
    public class BasePage
    {
        public static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        public void openLink(string link)
        {
            driver.Navigate().GoToUrl(link);
        }

        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}