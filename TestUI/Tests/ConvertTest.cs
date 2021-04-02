using NUnit.Framework;
using TestUI.Pages;


namespace TestUI.Tests
{
    public class ConvertTest : MainPage
    {
        string linkMainPage = "https://openweathermap.org/";

        public int tempC;
        public int tempF;
        
        [TestCase("Yoshkar-Ola")]
        [TestCase("London")]
        [TestCase("Moscow")]
        public void test_converter_temp_for_cities(string city)
        {
            openLink(linkMainPage);
            writeCity(city);
            clickSearchButton();
            clickOnCity();
            changeMetricToC();
            tempC = getTemperature("C");
            changeMetricToF();
            tempF = getTemperature("F");
            writeTempInConsole(tempC, tempF);
            checkEqual(tempC, tempF);
        }
    }
}