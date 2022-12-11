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
using Actions = OpenQA.Selenium.Interactions.Actions;

namespace HT_Design_Pattern.PageObjects
{

    public class SentPage : BasePage
    {
        public SentPage() : base("")
        {
        }

        public IWebElement SentField => Driver.GetInstance().FindElement(By.XPath("//a[contains(text(),'Sent')]"));

        public IWebElement SentMail => Driver.GetInstance().FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]"));

        public IWebElement newTextbox => Driver.GetInstance().FindElement(By.XPath("//div[@aria-label='Message Body']"));

        public IWebElement newSendField => Driver.GetInstance().FindElement(By.XPath("//div[text()='Send']"));

        public IWebElement updatedSentMail => Driver.GetInstance().FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]"));

        public IWebElement moreField => Driver.GetInstance().FindElement(By.XPath("//span[contains(text(),'More')]"));

        public IWebElement trashField => Driver.GetInstance().FindElement(By.XPath("//a[contains(text(),'Trash')]"));

        public IWebElement newSentMail => Driver.GetInstance().FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]"));

        public IWebElement AccountField => Driver.GetInstance().FindElement(By.CssSelector("img.gb_Ca.gbii"));

        public IWebElement SignOut => Driver.GetInstance().FindElement(By.XPath("//div[text()='Sign out']"));


        public void SendMails(string newMessage)
        {
            Actions ac = new Actions(Driver.GetInstance());

            WebDriverWait wait = new WebDriverWait(Driver.GetInstance(), TimeSpan.FromSeconds(50));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SentField));
            var SentButton = new Button(SentField);
            SentButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SentMail));
            ac.ContextClick(SentMail).Build().Perform();
            ac.SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Build().Perform();
            newTextbox.SendKeys(newMessage);
            ac.MoveToElement(newSendField).Click().Build().Perform();
           
        }

        public void DeleteMail()
        {
            Actions ac = new Actions(Driver.GetInstance());

            WebDriverWait wait = new WebDriverWait(Driver.GetInstance(), TimeSpan.FromSeconds(50));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(moreField));
            ac.MoveToElement(moreField).Build().Perform();
            ac.Click(moreField).Perform();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(trashField));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(newSentMail));

            ac.DragAndDrop(newSentMail, trashField).Build().Perform();
        }


        public void LogOut()
        {
            //AccountField.Click();
            var AccountButton = new Button(AccountField);
            AccountButton.Click();
            Driver.GetInstance().SwitchTo().Frame("account");
            //SignOut.Click();
            var SignOutButton = new Button(SignOut);
            SignOutButton.Click();
            Driver.GetInstance().SwitchTo().ParentFrame();
        }


    }

}
