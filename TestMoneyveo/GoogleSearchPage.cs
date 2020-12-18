using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;

namespace TestMoneyveo
{
    class GoogleSearchPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public GoogleSearchPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        public String GetTextFromResultN(int n)
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='rso']/div[@class='g'][" + n + "]")));
            return element.Text;
        }
    }
}
