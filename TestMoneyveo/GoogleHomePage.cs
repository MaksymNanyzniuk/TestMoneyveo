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

        [FindsBy(How = How.Name, Using = "btnK")]
        [CacheLookup]
        private IWebElement searchButton;

        public GoogleHomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void TypeText(String s)
        {
            searchField.SendKeys(s);
        }

        public void PressSearchButton()
        {
            searchButton.Click();
        }
    }
}
