using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using TestAssignment_NopCommerce.Pages;
using TestAssignment_NopCommerce.TestCases;

namespace TestAssignment_NopCommerce.TestCases
{

    public class TC_LoginUser
    {
        //fetch login credentials
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static string UserName = ConfigurationManager.AppSettings["UserName"];
        private static string Password = ConfigurationManager.AppSettings["Password"];
        [Test]
        public void LoginTest()
        {
            IWebDriver driver = null;
            try
            {
                Browsers.Init();
                driver = Browsers.getDriver;
                //driver.Url = "https://www.nopcommerce.com/";


                //driver.Manage().Window.Maximize();

                //driver.FindElement(By.XPath(".//*[contains(@href,'login')]")).Click();
                LoginPage.Link_Login(driver).Click();  //click login button to login
 
                //enter login credentials
                LoginPage.Txt_UserName(driver).SendKeys(UserName);
                LoginPage.Txt_Password(driver).SendKeys(Password);

                //click on login button 
                LoginPage.Btn_Login(driver).Click();

                //click logout button if login was successful
                if (LoginPage.Btn_Logout(driver).Enabled)
                {
                    System.Console.WriteLine("Login Successful");
                    driver.FindElement(By.XPath(".//*[contains(@href,'logout')]")).Click();
                    Assert.Pass();
                }


            }
            catch (StaleElementReferenceException ex)
            {
                log.Error("Exception in login. Login Failed " + ex.Message);
            }
            finally
            {
                //close browser always 
                Browsers.Close();
                //driver.Quit();
            }
        }
    }
}
