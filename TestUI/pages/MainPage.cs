using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestUI.pages
{
    public class MainPage : BasePage
    {
        int tempF = 0;
        int tempC = 0;

        public void enterCityName(string city)
        {
            IWebElement searchField =
                driver.FindElement(By.XPath("/html/body/main/div[2]/div[1]/div/div/div[2]/div[1]/div/input"));
            searchField.SendKeys(city);
        }

        public void clickSearchButton()
        {
            IWebElement searchButton =
                driver.FindElement(By.XPath("/html/body/main/div[2]/div[1]/div/div/div[2]/div[1]/button"));
            searchButton.Click();
        }

        public void clickOnCity()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                By.XPath("/html/body/main/div[2]/div[1]/div/div/div[2]/div[1]/div/ul/li")));
            IWebElement searchResult =
                driver.FindElement(By.XPath("/html/body/main/div[2]/div[1]/div/div/div[2]/div[1]/div/ul/li"));
            searchResult.Click();
        }

        public void changeMetricToC()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            
            // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
            //     By.XPath("/html/body/main/div/div[1]/div/div/div[1]/div/div[2]/div/label[1]")));
            var buttonToC = wait.Until(d =>
               driver.FindElement(By.XPath("/html/body/main/div/div[1]/div/div/div[1]/div/div[2]/div/label[1]")));
            buttonToC.Click();
        }

        public void getCelsius()
        {
            IWebElement displayedTempC =
                driver.FindElement(By.XPath("/html/body/main/div/div[2]/div[1]/div[1]/div[2]/div[1]/span"));
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(displayedTempC, "C"));
            tempC = Utils.getIntFromString(displayedTempC.Text);
        }

        public void changeMetricToF()
        {
            IWebElement buttonToF =
                driver.FindElement(By.XPath("/html/body/main/div/div[1]/div/div/div[1]/div/div[2]/div/label[2]"));
            buttonToF.Click();
        }

        public void getFahrenheit()
        {
            IWebElement displayedTempF =
                driver.FindElement(By.XPath("/html/body/main/div/div[2]/div[1]/div[1]/div[2]/div[1]/span"));
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(displayedTempF, "F"));
            tempF = Utils.getIntFromString(displayedTempF.Text);
        }

        public void writeTempInConsole()
        {
            Console.WriteLine("На сайте в С°: " + tempC);
            Console.WriteLine("При переводе с F° в C°: " + Utils.convertFtC(tempF));
            Console.WriteLine("На сайте в F°: " + tempF);
            Console.WriteLine("При переводе с C° в F°: " + Utils.convertCtF(tempC));
        }

        public void checkEqual()
        {
            Assert.That(tempC == Utils.convertFtC(tempF), "Несоответствие взятой с сайта " + tempC + " °C с полученной при перерасчете " + Utils.convertFtC(tempF) + " °C");
            Assert.That(tempF == Utils.convertCtF(tempC), "Несоответствие взятой с сайта " + tempF + " °F с полученной при перерасчете " + Utils.convertCtF(tempC) + " °F");
        }
        
    }
}