using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.PageObjects;

namespace Structura.GuiTests.PageObjects
{
    public class EditUsers
    {
        private readonly IWebDriver _driver;

        public EditUsers(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement EditUserInformationHeader => _driver.FindElement(By.TagName("h1"));
    }
}
