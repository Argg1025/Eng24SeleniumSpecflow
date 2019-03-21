using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Eng24SeleniumSpecflow
{
    public class BBCLoginPage
    {
        private readonly IWebDriver _driver;

        // PageFactory Objects
        [FindsBy(How = How.Id, Using = "user-identifier-input")]
        private IWebElement _username;
        [FindsBy(How = How.Id, Using = "password-input")]
        private IWebElement _password;
        [FindsBy(How = How.Id, Using = "submit-button")]
        private IWebElement _submitButton;
        [FindsBy(How = How.Id, Using = "form-message-password")]
        private IWebElement _errorText;


        private const string PageUri = @"http://bbc.co.uk/signin";

        public BBCLoginPage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(_driver, this);
        }

        public static BBCLoginPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUri);

            return new BBCLoginPage(driver);
        }

        public string Username
        {
            set
            {
                _username.SendKeys(value);
            }
        }

        public string Password
        {
            set
            {
                _password.SendKeys(value);
            }
        }

        public void ClickSigninButtton()
        {
            _submitButton.Click();
        }

        public string ErrorText =>
            _errorText.Text;
    }
}
