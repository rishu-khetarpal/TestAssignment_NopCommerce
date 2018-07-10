using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;
using TestAssignment_NopCommerce.Pages;
using TestAssignment_NopCommerce.TestCases;


namespace TestAssignment_NopCommerce
{

    public class TC_RegisterUser
    {
        //fetch all values for registration 
        private static string FirstName = ConfigurationManager.AppSettings["FirstName"];
        private static string LastName = ConfigurationManager.AppSettings["LastName"];
        private static string Email = ConfigurationManager.AppSettings["Email"];
        private static string Country = ConfigurationManager.AppSettings["Country"];
        private static string Role = ConfigurationManager.AppSettings["Role"];
        private static string UserName = ConfigurationManager.AppSettings["UserName"];
        private static string Password = ConfigurationManager.AppSettings["Password"];

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [Test]
        public void Register_User()
        {
            IWebDriver driver = null;
            //IWebDriver driver = new ChromeDriver();
            try
            {
                // driver.Manage().Window.Maximize();
                //driver.Url = "https://www.nopcommerce.com/";

                Browsers.Init();
                driver = Browsers.getDriver;

                try
                {
                    HomePage.Lnk_RegisterNewUser(driver).Click();   //click on register button
                }
                catch (Exception e)
                {
                    log.Error("Register Link not Found" + e.Message);  //otherwise throw exception
                }

                //Enter registeration details if page opens successfully
                RegistrationPage.Txt_FirstName(driver).SendKeys(FirstName);
                RegistrationPage.Txt_LastName(driver).SendKeys(LastName);
                RegistrationPage.Txt_Email(driver).SendKeys(Email);
                RegistrationPage.Txt_UserName(driver).SendKeys(UserName);
                RegistrationPage.Ddl_Country(driver).SendKeys(Country);
                RegistrationPage.Ddl_Role(driver).SendKeys(Role);
                RegistrationPage.Txt_Password(driver).SendKeys(Password);
                RegistrationPage.Txt_CnfPassword(driver).SendKeys(Password);
                RegistrationPage.Btn_Register(driver).Click();  //click register button


                if (RegistrationPage.Txt_SuccessMessage(driver).Text.Contains("Your registration completed"))
                {
                    log.Info("Registration Successful");
                    Assert.Pass();
                }
                else if (RegistrationPage.Txt_ErrorMessageOnRegPage(driver).Enabled)
                {
                    log.Error(RegistrationPage.Txt_ErrorMessageOnRegPage(driver).Text);
                    Assert.Fail();

                }

            }
            catch (StaleElementReferenceException ex)
            {
                log.Error("Exception is thrown" + ex.Message);
                Assert.Fail();
            }

            finally
            {
                //close browser always
                //Browsers.Close();    
                driver.Quit();
            }
        }
    }
}