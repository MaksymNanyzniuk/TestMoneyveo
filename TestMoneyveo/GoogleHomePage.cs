using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace TestMoneyveo
{
    class GoogleHomePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Name, Using = "q")]
        [CacheLookup]
        private IWebElement searchField;

        public GoogleHomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void SearchText(String s)
        {
            searchField.SendKeys(s + Keys.Enter);
        }
    }
}
