using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;

namespace TestMoneyveo
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver("D:\\Java\\ChromeDriver87");
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.google.com/";
        }

        [Test]
        public void Test1()
        {
            //Arrange
            String textToSearch = "Selenium IDE export to C#";
            int resultNumber = 4;
            String expectedResult = "Selenium IDE";

            // Act
            GoogleHomePage homePage = new GoogleHomePage(driver);
            homePage.SearchText(textToSearch);
            GoogleSearchPage searchPage = new GoogleSearchPage(driver, TimeSpan.FromSeconds(10));
            String actualResult = searchPage.GetTextFromResultN(resultNumber);

            //Assert
            Debug.WriteLine("---------------Result:" + actualResult);
            Assert.IsTrue(actualResult.Contains(expectedResult));
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}