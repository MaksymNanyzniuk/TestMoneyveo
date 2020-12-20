using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;

namespace TestMoneyveo
{
    class GoogleSearchPage : Page
    {
        public GoogleSearchPage(IWebDriver driver, TimeSpan defaultTimeSpan) : base (driver, defaultTimeSpan)
        {
        }

        public String GetTextFromResultN(int n)
        {
            String xPath = "//div[@id='rso']/div[starts-with(@class,'g')][" + n + "]";
            IWebElement webElement = Find(xPath, Locator.XPath);
            return webElement.Text;
        }
    }
}
