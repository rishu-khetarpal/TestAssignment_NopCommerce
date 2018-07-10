using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Configuration;


namespace TestAssignment_NopCommerce.TestCases
{
    public class Browsers
    {
        private static IWebDriver webDriver;
        private static string baseURL = ConfigurationManager.AppSettings["URL"];
        private static string browser = ConfigurationManager.AppSettings["browser"];
        public static void Init()
        {
            //create cases so that it can be tested on all browsers
            switch (browser)
            {
                case "Chrome":
                    webDriver = new ChromeDriver();
                    break;
                case "IE":
                    webDriver = new InternetExplorerDriver();
                    break;
                case "Firefox":
                    webDriver = new FirefoxDriver();
                    break;
            }
            webDriver.Manage().Window.Maximize();
            Goto(baseURL);
        }

        //Get title of browser
        public static string Title
        {
            get { return webDriver.Title; }
        }
        public static IWebDriver getDriver
        {
            get { return webDriver; }
        }


        public static void Goto(string url)
        {
            webDriver.Url = url;
        }
        public static void Close()
        {
            webDriver.Quit();
        }
    }
}
