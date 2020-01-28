using System;
using System.Globalization;
using System.Text;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using Structura.GuiTests.PageObjects;
using Structura.GuiTests.SeleniumHelpers;
using Structura.GuiTests.Utilities;
using Tests.PageObjects;

namespace Structura.GuiTests
{
    [TestFixture]
    public class AltoroMutualTests
    {
        private IWebDriver _driver;
        private StringBuilder _verificationErrors;
        private string _baseUrl;

        [SetUp]
        public void SetupTest()
        {
            _driver = new DriverFactory().Create();
            _baseUrl = ConfigurationHelper.Get<string>("TargetUrl");
            _verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                _driver.Quit();
                _driver.Close();
            }
            catch (Exception)
            {
                // Ignore errors if we are unable to close the browser
            }
            _verificationErrors.ToString().Should().BeEmpty("No verification errors are expected.");
        }

        [Test]
        public void LoginWithValidCredentialsShouldSucceed()
        {
            // Arrange
            var expected = true; //Login Success 

            // Act
            new LoginPage(_driver).LoginAsAdmin(_baseUrl);

            // Assert
            var actual = new MainPage(_driver).GetAccountButton.Displayed;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LoginWithInvalidCredentialsShouldFail()
        {
            // Arrange
            // Act
            new LoginPage(_driver).LoginAsNobody(_baseUrl);

            // Assert
            Action a = () =>
            {
                var displayed = new MainPage(_driver).GetAccountButton.Displayed; // throws exception if not found
            };
            a.ShouldThrow<NoSuchElementException>();
        }
        
        [Test]
        public void RequestGoldenVisaShouldBeAccepted()
        {
            // Arrange
            new LoginPage(_driver).LoginAsAdmin(_baseUrl);
            var page = new RequestGoldVisaPage(_driver);
            new MainPage(_driver).NavigateToTransferFunds();

            // Act
            page.PerformRequest();

            // Assert

            // Need to wait until the results are displayed on the web page
            Thread.Sleep(500); //Hard sleeps are bad! Don't use them.
            
            page.SuccessMessage.Text.StartsWith(
                "Your new Altoro Mutual Gold VISA with a $10000 and 7.9% APR will be sent in the mail."
                , true, CultureInfo.InvariantCulture).Should().BeTrue();
        }
    }
}


