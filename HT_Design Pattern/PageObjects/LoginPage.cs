using Nest;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace HT_Design_Pattern.PageObjects
{
    public class LoginPage : BasePage
    {
        public LoginPage() : base("")
        {
        }

        public IWebElement UsernameField => Driver.GetInstance().FindElement(By.Id("identifierId"));
        public IWebElement NextButton => Driver.GetInstance().FindElement(By.Id("identifierNext"));
        public IWebElement PasswordField => Driver.GetInstance().FindElement(By.XPath("//*[@id='password']//input"));
        public IWebElement LoginButton => Driver.GetInstance().FindElement(By.Id("passwordNext"));
        public IWebElement MainPage => Driver.GetInstance().FindElement(By.CssSelector("body"));

        //TODO string senderMail, string subject, string textbox parameter values are not used in function
        public void Login(string username, string password)
        {

            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Driver.GetInstance();

            WebDriverWait wait = new WebDriverWait(Driver.GetInstance(), TimeSpan.FromSeconds(50));
            jsExecutor.ExecuteScript("arguments[0].setAttribute('style', 'border:2px solid red; background:yellow')", UsernameField);
            UsernameField.SendKeys(username); //pass this value from test
            //NextButton.Click();
            jsExecutor.ExecuteScript("arguments[0].click();", NextButton);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(PasswordField));
            PasswordField.SendKeys(password); //pass this value from test
            //LoginButton.Click();
            var PasswordButton = new Button(LoginButton);
            PasswordButton.Click();

        }
    }
}