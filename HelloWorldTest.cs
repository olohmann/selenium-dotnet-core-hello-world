using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace SeleniumHelloWorld
{
    public class HelloWorldTest
    {
        [Fact]
        public void HelloWorld()
        {
            var options = new ChromeOptions();
            //options.AddArgument("--headless");
            options.AddArgument("--window-size=1920,1080");
            using(var driver = new ChromeDriver(".", options)) // for some reason, the chromedriver is not automatically picked up if we do not specify the current directory explicitly here...
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.Navigate().GoToUrl("https://www.google.com");
                driver.FindElement(By.Name("q")).SendKeys("42");
                driver.FindElement(By.Name("btnK")).Click();
                Assert.True(driver.PageSource.Contains("Douglas Adams"), $"Page with title '{driver.Title}' does not contain expected search term.");
            }
        }
    }
}
