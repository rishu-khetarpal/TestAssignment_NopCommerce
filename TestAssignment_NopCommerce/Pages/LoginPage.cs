using OpenQA.Selenium;

namespace TestAssignment_NopCommerce.Pages
{
    //to find elements of login section
    public class LoginPage
    {
        //private static IWebElement element = null;
        public static IWebElement Txt_UserName(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.XPath(".//input[contains(@id, 'UserName')]"));
            return element;
        }

        public static IWebElement Txt_Password(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.XPath(".//input[contains(@id, 'Password')]"));
            return element;
        }

        public static IWebElement Link_Login(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.XPath(".//*[contains(@href,'login')]"));
            return element;
        }

        public static IWebElement Btn_Login(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.XPath(".//input[contains(@id,'LoginButton')]"));
            return element;
        }

        public static IWebElement Btn_Logout(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.XPath(".//*[contains(@href,'logout')]"));
            return element;
        }



    }
}
