using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.SeleniumHelpers;

namespace Tests.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement SignInLink => _driver.FindElement(By.Id("AccountLink"));
        public IWebElement UserIdField => _driver.FindElement(By.Id("uid"));
        public IWebElement PasswordField => _driver.FindElement(By.Id("passw"));
        public IWebElement LoginButton => _driver.FindElement(By.CssSelector("input[name='btnSubmit']"));

        public void LoginAsAdmin(string baseUrl)
        {
            _driver.Navigate().GoToUrl(baseUrl);
            SignInLink.Click();
            UserIdField.Clear();
            // sending a single quote is not possible with the Chrome Driver, it sends two single quotes!
            UserIdField.SendKeys("admin'--");

            PasswordField.Clear();
            PasswordField.SendKeys("blah");

            LoginButton.Click();
        }

        public void LoginAsNobody(string baseUrl)
        {
            _driver.Navigate().GoToUrl(baseUrl);
            SignInLink.Click();

            UserIdField.Clear();
            UserIdField.SendKeys("nobody");

            PasswordField.Clear();
            PasswordField.SendKeys("blah");

            LoginButton.Click();
        }
    }
}