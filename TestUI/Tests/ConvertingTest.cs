using NUnit.Framework;
using TestUI.pages;


namespace TestUI.Tests
{
    public class ConvertingTest : MainPage
    {
        string linkMainPage = "https://openweathermap.org/";

        [TestCase("Yoshkar-Ola")]
        [TestCase("London")]
        [TestCase("Moscow")]
        public void test_converter_temp_for_cities(string city)
        {
            openLink(linkMainPage);
            enterCityName(city);
            clickSearchButton();
            clickOnCity();
            changeMetricToC();
            getCelsius();
            changeMetricToF();
            getFahrenheit();
            writeTempInConsole();
            checkEqual();
        }
    }
}