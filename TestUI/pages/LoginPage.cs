using NUnit.Framework;
using OpenQA.Selenium;

namespace TestUI.pages
{
    public class LoginPage: BasePage
    {

        public void findSignButtonAndGo()
        {
            IWebElement signButton = driver.FindElement(By.Id("sign_in"));
            signButton.Click();
        }

        public void findSignUpButtonAndGo()
        {
            IWebElement signButton = driver.FindElement(By.LinkText("Create an Account."));
            signButton.Click();
        }
        
        public void checkCurrentLinkEqualReference(string link)
        {
            Assert.That(driver.Url == link, "Текущий адрес страницы " + driver.Url + " не совпадает с ожидаемым " + link);
        }

        public void writeMail(string mail)
        {
            IWebElement emailField = driver.FindElement(By.Id("user_email"));
            emailField.SendKeys(mail);
        }

        public void writePassword(string password)
        {
            IWebElement passwordField = driver.FindElement(By.Id("user_password"));
            passwordField.SendKeys(password);
        }

        public void signButton()
        {
            IWebElement button = driver.FindElement(By.Name("commit"));
            button.Click();
        }
    }
}