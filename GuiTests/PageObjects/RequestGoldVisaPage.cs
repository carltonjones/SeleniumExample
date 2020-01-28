using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.SeleniumHelpers;

namespace Structura.GuiTests.PageObjects
{
    public class RequestGoldVisaPage
    {
        private readonly IWebDriver _driver;

        public RequestGoldVisaPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement SubmitButton => _driver.FindElement(By.CssSelector("form[name='Credit'] input[type='submit']"));
        public IWebElement PasswordField => _driver.FindElement(By.CssSelector("input[name='passwd']"));
        public IWebElement SuccessMessage => _driver.FindElement(By.Id("_ctl0__ctl0_Content_Main_lblMessage"));

        public void PerformRequest()
        {
            PasswordField.Clear();
            // sending a single quote is not possible with the Chrome Driver, it sends two single quotes!
            PasswordField.SendKeys("pass'--");
            SubmitButton.Click();
        }
    }
}
