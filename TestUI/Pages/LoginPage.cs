using NUnit.Framework;
using OpenQA.Selenium;
using static TestUI.Pages.Locators;

namespace TestUI.Pages
{
    public class LoginPage : BasePage
    {
        public void findSignButtonAndGo()
        {
            driver.FindElement(By.Id(LoginLocators.SIGN_IN)).Click();
        }

        public void findSignUpButtonAndGo()
        {
            driver.FindElement(By.LinkText(LoginLocators.SIGN_UP)).Click();
        }

        public void writeMail(string mail)
        {
            driver.FindElement(By.Id(LoginLocators.USER_MAIL)).SendKeys(mail);
        }

        public void writePassword(string password)
        {
            driver.FindElement(By.Id(LoginLocators.USER_PASSWORD)).SendKeys(password);
        }

        public void signButton()
        {
            driver.FindElement(By.Name(LoginLocators.SIGN_BUTTON)).Click();
        }

        public void checkCurrentLinkEqualReference(string link)
        {
            Assert.That(driver.Url == link,
                "Текущий адрес страницы " + driver.Url + " не совпадает с ожидаемым " + link);
        }
    }
}