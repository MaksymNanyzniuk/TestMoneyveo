using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;

namespace TestMoneyveo
{
    class Page
    {
        private IWebDriver driver;
        private TimeSpan defaultTimeSpan;

        public Page(IWebDriver driver, TimeSpan defaultTimeSpan)
        {
            this.driver = driver;
            this.defaultTimeSpan = defaultTimeSpan;
        }

        public Page(IWebDriver driver)
        {
            this.driver = driver;
        }

        public enum Locator
        {
            Id,
            Name,
            TagName,
            ClassName,
            LinkText,
            PartialLinkText,
            XPath,
            CssSelector
        }

        private By ByLocator(string element, Locator locator)
        {
            switch(locator)
            {
                case Locator.Id:
                    return By.Id(element);
                case Locator.Name:
                    return By.Name(element);
                case Locator.TagName:
                    return By.TagName(element);
                case Locator.ClassName:
                    return By.ClassName(element);
                case Locator.LinkText:
                    return By.LinkText(element);
                case Locator.PartialLinkText:
                    return By.PartialLinkText(element);
                case Locator.XPath:
                    return By.XPath(element);
                case Locator.CssSelector:
                    return By.CssSelector(element);
                default:
                    throw new Exception("No Locator Found");
            }
        }

        public IWebElement Find(string element, Locator locator)
        {
            return driver.FindElement(ByLocator(element, locator));
        }

        public Page Fill(string element, Locator locator, string value)
        {
            Find(element, locator).Clear();
            Find(element, locator).SendKeys(value);
            return this;
        }

        public Page WaitUntil(Func<IWebDriver, Page> condition)
        {
            new WebDriverWait(driver, this.defaultTimeSpan).Until(condition);
            return this;
        }

        public Page NavigateTo(string url, string proofElement, Locator locator)
        {
            driver.Navigate().GoToUrl(url);
            new WebDriverWait(driver, this.defaultTimeSpan).Until(d => d.FindElement(ByLocator(proofElement, locator)));
            return this;
        }
    }
}
