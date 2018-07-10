using OpenQA.Selenium;

namespace TestAssignment_NopCommerce.Pages
{
    public class RegistrationPage
    {
        //find and return all the elements used on registration page
        public static IWebElement Txt_FirstName(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.XPath(".//input[contains(@id, 'txtFirstName')]"));
            return element;
        }

        public static IWebElement Txt_LastName(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.XPath(".//input[contains(@id, 'txtLastName')]"));
            return element;
        }

        public static IWebElement Txt_Email(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.XPath(".//input[contains(@id, 'Email')]"));
            return element;
        }

        public static IWebElement Txt_UserName(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.XPath(".//input[contains(@id, 'UserName')]"));
            return element;
        }

        public static IWebElement Ddl_Country(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.XPath(".//select[contains(@id, 'ddlCountry')]"));
            return element;
        }
        public static IWebElement Ddl_Role(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.XPath(".//select[contains(@id, 'ddlRole')]"));
            return element;
        }
        public static IWebElement Txt_Password(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.XPath(".//input[contains(@id, 'Password')]"));
            return element;
        }
        public static IWebElement Txt_CnfPassword(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.XPath(".//input[contains(@id, 'ConfirmPassword')]"));
            return element;
        }

        public static IWebElement Btn_Register(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.XPath(".//input[contains(@id,'StepNextButton')]"));
            return element;
        }
        public static IWebElement Txt_SuccessMessage(IWebDriver driver)
        {

            IWebElement element = driver.FindElement(By.XPath(".//*[contains(@id,'lblCompleteStep')]"));
            return element;
        }

        public static IWebElement Txt_ErrorMessageOnRegPage(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.XPath(".//*[contains(@class,'message-error')]"));
            return element;
        }



    }
}
