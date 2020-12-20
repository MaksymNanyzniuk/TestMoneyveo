using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace TestMoneyveo
{
    class GoogleHomePage : Page
    {
        public GoogleHomePage(IWebDriver driver) : base (driver)
        {
        }

        public void SearchText (string s)
        {
            Fill("q", Locator.Name, s + Keys.Enter);
        }
    }
}
