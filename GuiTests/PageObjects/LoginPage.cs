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
        public IWebElement SignInByLinkText => _driver.FindElement(By.LinkText("ONLINE BANKING LOGIN"));
        public IWebElement SignInLinkCSS => _driver.FindElement(By.CssSelector("#AccountLink"));
        public IWebElement SignInLinkXpath => _driver.FindElement(By.XPath("//*[@id='AccountLink']"));
        public IWebElement SignInLinkFullXpath => _driver.FindElement(By.XPath("/html/body/table/tbody/tr[1]/td[1]/div/a")); //Full XPath locators are a bad idea because if ANYTHING changes it will probably break!


        public IWebElement UserIdField => _driver.FindElement(By.Id("uid"));
        public IWebElement PasswordField => _driver.FindElement(By.Id("passw"));
        public IWebElement LoginButton => _driver.FindElement(By.CssSelector("input[name='btnSubmit']"));

        

        public void LoginAsAdmin(string baseUrl)
        {
            _driver.Navigate().GoToUrl(baseUrl);

            //Found Using different types of Locators but all finding the same Element
            //var linkById = SignInLink;
            //var linkByLinkText = SignInByLinkText;
            //var linkByCSS = SignInLinkCSS;
            //var linkByXPath = SignInLinkXpath;
            //var linkByFullXPath = SignInLinkFullXpath;

            //A better example of css locators as well as finding multiple elements using .FindElements (notice the 's') - will get all matching elements
            //var subHeaders = _driver.FindElements(By.CssSelector(".subheader"));

            SignInLink.Click();
            UserIdField.Clear();
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