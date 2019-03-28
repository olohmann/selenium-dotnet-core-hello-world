# Hello World - Selenium meets .NET Core

## Introduction

Quick and dirty demo to run Selenium Test on .NET Core.

## Acknowledgements

This awesome demo snippet was first put together by [Carsten Duellmann](https://github.com/cadullms). All credits to Carsten for this one!

## Demo Steps

```sh
dotnet new xunit -n SeleniumHelloWorld
cd SeleniumHelloWorld
dotnet test

dotnet add package Selenium.WebDriver
dotnet add package Selenium.WebDriver.ChromeDriver
```

Modify `UnitTest1.cs`

```csharp
using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumHelloWorld
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var driver = new ChromeDriver(".");
            driver.Navigate().GoToUrl("https://google.com");
        }
    }
}
```

Run it... Will open Chrome and test stops.

```csharp
    [Fact]
    public void Test1()
    {
        var options = new ChromeOptions();
        options.AddArgument("--headless");
        options.AddArgument("--window-size=1920,1080");
        using (var driver = new ChromeDriver(".", options)) // for some reason, the chromedriver is not automatically picked up if we do not specify the current directory explicitly here...
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.FindElement(By.Name("q")).SendKeys("42");
            driver.FindElement(By.Name("btnK")).Click();
            Assert.IsTrue(driver.PageSource.Contains("Douglas Adams"), $"Page with title '{driver.Title}' does not contain expected search term.");
        }
    }
```
