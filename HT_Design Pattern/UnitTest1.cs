using HT_Design_Pattern.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HT_Design_Pattern.PageObjects;
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
using Assert = NUnit.Framework.Assert;
using log4net.Config;
using log4net.Appender;
using log4net;
using NUnit.Framework.Interfaces;
using TestContext = NUnit.Framework.TestContext;


namespace HT_Design_Pattern
{
    [TestFixture]
    public class UnitTest1 
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [TestCase]
        public void TestMethod1()
        {
            log.Debug("Trying to send a mail");
            try
            {
                var loginPage = new LoginPage();
                loginPage.Open();
                loginPage.Login("aadilmuhammadu@gmail.com", "Test@123");
                Assert.AreEqual(loginPage.UsernameField.GetAttribute("value"), "aadilmuhammadu@gmail.com");
                Assert.AreEqual(loginPage.PasswordField.GetAttribute("value"), "Test@123");
                //Assert for login is successful
                Assert.True(loginPage.MainPage.Displayed, "The login is successful");  
                var InboxPage = new InboxPage();
                InboxPage.Compose("aadilmisba3@gmail.com", "Sample Subject", "Test Mail");
                var DraftPage = new DraftPage();
                DraftPage.DraftMails();
                
                var SentPage = new SentPage();
                SentPage.SendMails("Updated");
                SentPage.DeleteMail();
                //SentPage.LogOut();
            }
            catch (Exception ex)
            {
                log.Error("Error occured", ex);
                throw;
            }
            log.Debug("Mail sent");

        }

        [TearDown]
        public void Cleanup()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                Driver.captureSS();
            }
            Driver.Close();
        }


    }
}