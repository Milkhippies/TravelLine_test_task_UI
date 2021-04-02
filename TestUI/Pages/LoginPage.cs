using NUnit.Framework;
using OpenQA.Selenium;
using static TestUI.Pages.Locators;

namespace TestUI.Pages
{
    public class LoginPage : BasePage
    {
        public void findSignButtonAndGo()
        {
            var signINButton = driver.FindElement(By.Id(LoginLocators.SIGN_IN));
            signINButton.Click();
        }

        public void findSignUpButtonAndGo()
        {
            var signUPButton = driver.FindElement(By.LinkText(LoginLocators.SIGN_UP));
            signUPButton.Click();
        }

        public void writeMail(string mail)
        {
            var mailField = driver.FindElement(By.Id(LoginLocators.USER_MAIL));
            mailField.SendKeys(mail);
        }

        public void writePassword(string password)
        {
            var passwordField = driver.FindElement(By.Id(LoginLocators.USER_PASSWORD));
            passwordField.SendKeys(password);
        }

        public void signButton()
        {
            var signButton = driver.FindElement(By.Name(LoginLocators.SIGN_BUTTON));
            signButton.Click();
        }

        public void findBadAuthMessage()
        {
            var alertMessage = driver.FindElement(By.ClassName(LoginLocators.BAD_AUTH_ALERT));
            Assert.That(alertMessage.Text.Contains("Invalid Email or password"));
        }
        
        public void checkCurrentLinkEqualReference(string link)
        {
            Assert.That(driver.Url == link,
                "Текущий адрес страницы " + driver.Url + " не совпадает с ожидаемым " + link);
        }
    }
}