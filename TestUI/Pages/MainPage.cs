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
            var cityField = driver.FindElement(By.XPath(MainLocators.WRITE_CITY));
            cityField.SendKeys(city);
        }
        
        public void clickSearchButton()
        {
            var searchButton = driver.FindElement(By.XPath(MainLocators.SEARCH_CITY_BUTTON));
            searchButton.Click();
        }

        public void clickOnCity()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            var chooseCity = wait.Until(d => driver.FindElement(By.XPath(MainLocators.CLICK_CITY)));
            chooseCity.Click();
        }

        public void changeMetricToC()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            var metricСButton = wait.Until(ElementIsVisible(By.XPath(MainLocators.METRIC_TO_C)));
            metricСButton.Click();
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
            var metricFButton = driver.FindElement(By.XPath(MainLocators.METRIC_TO_F));
            metricFButton.Click();
        }

        public void writeTempInConsole(int tempC, int tempF)
        {
            Console.WriteLine("На сайте в С°: " + tempC);
            Console.WriteLine("При переводе из F° в C°: " + Utils.convertFtC(tempF));
            Console.WriteLine("На сайте в F°: " + tempF);
            Console.WriteLine("При переводе из C° в F°: " + Utils.convertCtF(tempC));
        }

        public void checkEqual(int tempC, int tempF)
        {
            Assert.That(tempC == Utils.convertFtC(tempF), "Несоответствие взятой с сайта " + tempC + " °C с полученной при перерасчете " + Utils.convertFtC(tempF) + " °C");
            Assert.That(tempF == Utils.convertCtF(tempC), "Несоответствие взятой с сайта " + tempF + " °F с полученной при перерасчете " + Utils.convertCtF(tempC) + " °F");
        }
        
    }
}