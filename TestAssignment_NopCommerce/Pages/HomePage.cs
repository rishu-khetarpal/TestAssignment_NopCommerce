using OpenQA.Selenium;

namespace TestAssignment_NopCommerce.Pages
{
    class HomePage
    {
        public static IWebElement Lnk_RegisterNewUser(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.ClassName("ico-register"));
            return element;
        }
    }
}