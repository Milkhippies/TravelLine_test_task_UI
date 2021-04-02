using NUnit.Framework;
using TestUI.pages;


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
        public void test_authorization_form()
        {
            openLink(linkLogin);
            writeMail(mail);
            writePassword(password);
            signButton();
            checkCurrentLinkEqualReference(linkHome);

        }
        
        
    }
}