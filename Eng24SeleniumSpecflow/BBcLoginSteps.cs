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
        private IWebDriver driver; 
        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://bbc.co.uk");
            IWebElement loginButton = driver.FindElement(By.Id("idcta-link"));
            loginButton.Click();
        }
        
        [Given(@"I have entered a valid username")]
        public void GivenIHaveEnteredAValidUsername()
        {
            IWebElement usernameField = driver.FindElement(By.Id("user-identifier-input"));
            usernameField.SendKeys("testing@goddard.com");
        }
        
        [Given(@"I have entered an invalid password")]
        public void GivenIHaveEnteredAnInvalidPassword()
        {
            IWebElement passwordField = driver.FindElement(By.Id("password-input"));
            passwordField.SendKeys("12345678");
        }
        
        [When(@"I press login")]
        public void WhenIPressLogin()
        {
            IWebElement submitButton = driver.FindElement(By.Id("submit-button"));
            submitButton.Click();
        }
        
        [Then(@"I should see the appropriate error")]
        public void ThenIShouldSeeTheAppropriateError()
        {
            IWebElement passwordError = driver.FindElement(By.Id("form-message-password"));
            Assert.AreEqual("Sorry, that password isn't valid. Please include a letter.", passwordError.Text);
        }
    }
}
