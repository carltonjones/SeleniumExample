using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.PageObjects;

namespace Structura.GuiTests.PageObjects
{
    public class MainPage
    {
        private readonly IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement GetAccountButton => _driver.FindElement(By.Id("btnGetAccount"));
        public IWebElement TransferFundsButton => _driver.FindElement(By.XPath("//*[@id=\"_ctl0__ctl0_Content_Main_promo\"]/table/tbody/tr[3]/td/a"));

        public RequestGoldVisaPage NavigateToTransferFunds()
        {
            TransferFundsButton.Click();
            return new RequestGoldVisaPage(_driver);
        }
    }
}
