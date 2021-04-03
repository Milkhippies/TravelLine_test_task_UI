using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TestUI.Pages;


namespace TestUI.Tests
{

    public class LoginTest: LoginPage
    {

        string linkMainPage = "https://openweathermap.org/";
        string linkLogin = "https://home.openweathermap.org/users/sign_in";
        string linkHome = "https://home.openweathermap.org/";
        string linkRegistration = "https://home.openweathermap.org/users/sign_up";

        string mail = "wemtiqeurqjvkvevbz@twzhhq.online";
        string password = "12345679";
        
        [Test]
        public void test_link_from_main_to_login()
        {
            openLink(linkMainPage);
            findSignButtonAndGo();
            checkCurrentLinkEqualReference(linkLogin);
        }

        [Test]
        public void test_link_from_login_to_registration()
        {
            openLink(linkLogin);
            findSignUpButtonAndGo();
            checkCurrentLinkEqualReference(linkRegistration);
        }

        [Test]
        public void test_correct_authorization()
        {
            openLink(linkLogin);
            writeMail(mail);
            writePassword(password);
            signButton();
            checkCurrentLinkEqualReference(linkHome);

        }
        
        [Test]
        public void test_incorrect_authorization_bad_password()
        {
            openLink(linkLogin);
            writeMail(mail);
            writePassword(password+"1");
            signButton();
            findBadAuthMessage();
        }
        
        [Test]
        public void test_incorrect_authorization_bad_email()
        {
            openLink(linkLogin);
            writeMail(mail+"1");
            writePassword(password);
            signButton();
            findBadAuthMessage();
        }
        
    }
}