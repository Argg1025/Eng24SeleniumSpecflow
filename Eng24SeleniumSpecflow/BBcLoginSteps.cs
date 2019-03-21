using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace Eng24SeleniumSpecflow
{
    [Binding]
    public class BBcLoginSteps
    {
        private IWebDriver _driver;
        private BBCLoginPage _bbcLoginPage;


        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _bbcLoginPage = BBCLoginPage.NavigateTo(_driver);

        }
        
        [Given(@"I have entered a valid (.*)")]
        public void GivenIHaveEnteredAValidUsername(string username)
        {
            _bbcLoginPage.Username = username;
        }
        
        [Given(@"I have entered an invalid (.*)")]
        public void GivenIHaveEnteredAnInvalidPassword(string password)
        {
            _bbcLoginPage.Password = password;
        }
        
        [When(@"I press login")]
        public void WhenIPressLogin()
        {
            _bbcLoginPage.ClickSigninButtton();
        }
        
        [Then(@"I should see the appropriate (.*)")]
        public void ThenIShouldSeeTheAppropriateError(string error)
        { 
            Assert.AreEqual(error, _bbcLoginPage.ErrorText);
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _driver.Dispose();
        }
    }
}
