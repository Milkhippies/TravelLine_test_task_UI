using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;
using static TestUI.Pages.Locators;

namespace TestUI.Pages
{
    public class MainPage : BasePage
    {

        public void writeCity(string city)
        {
            driver.FindElement(By.XPath(MainLocators.WRITE_CITY)).SendKeys(city);
        }
        
        public void clickSearchButton()
        {
            driver.FindElement(By.XPath(MainLocators.SEARCH_CITY_BUTTON)).Click();
        }

        public void clickOnCity()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(d => driver.FindElement(By.XPath(MainLocators.CLICK_CITY))).Click();
        }

        public void changeMetricToC()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ElementToBeClickable(By.XPath(MainLocators.METRIC_TO_C))).Click();
            
            // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
            //     By.XPath("/html/body/main/div/div[1]/div/div/div[1]/div/div[2]/div/label[1]")));
            
            // var buttonToC = wait.Until(d =>
            //    driver.FindElement(By.XPath(Locators.MainLocators.METRIC_TO_C)));
            //buttonToC.Click();
        }
        
        public int getTemperature(string degrees)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            var displayedTemp = driver.FindElement(By.XPath(MainLocators.TEMPERATURE_STRING));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(displayedTemp, degrees));
            return Utils.getIntFromString(displayedTemp.Text);
        }
        
        public void changeMetricToF()
        {
            driver.FindElement(By.XPath(MainLocators.METRIC_TO_F)).Click();
        }

        public void writeTempInConsole(int tempC, int tempF)
        {
            Console.WriteLine("На сайте в С°: " + tempC);
            Console.WriteLine("При переводе с F° в C°: " + Utils.convertFtC(tempF));
            Console.WriteLine("На сайте в F°: " + tempF);
            Console.WriteLine("При переводе с C° в F°: " + Utils.convertCtF(tempC));
        }

        public void checkEqual(int tempC, int tempF)
        {
            Assert.That(tempC == Utils.convertFtC(tempF), "Несоответствие взятой с сайта " + tempC + " °C с полученной при перерасчете " + Utils.convertFtC(tempF) + " °C");
            Assert.That(tempF == Utils.convertCtF(tempC), "Несоответствие взятой с сайта " + tempF + " °F с полученной при перерасчете " + Utils.convertCtF(tempC) + " °F");
        }
        
    }
}