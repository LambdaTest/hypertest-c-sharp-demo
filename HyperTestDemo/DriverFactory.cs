using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;

namespace HyperTestDemo
{
    public class DriverFactory
    {
        // makeSlowerFactor kept for call-site compatibility; the artificial
        // EventFiringWebDriver slow-down from the original demo was removed.
        public static IWebDriver GetDriver(string testName, int makeSlowerFactor = 1)
        {
            string username = Environment.GetEnvironmentVariable("LT_USERNAME")
                ?? throw new InvalidOperationException("LT_USERNAME environment variable is not set");
            string authkey = Environment.GetEnvironmentVariable("LT_ACCESS_KEY")
                ?? throw new InvalidOperationException("LT_ACCESS_KEY environment variable is not set");

            var options = new ChromeOptions
            {
                BrowserVersion = "latest",
            };
            var ltOptions = new Dictionary<string, object>
            {
                ["user"] = username,
                ["accessKey"] = authkey,
                ["build"] = "HyperExecute C# NUnit Demo",
                ["name"] = testName,
                ["platformName"] = "Windows 10",
            };
            options.AddAdditionalOption("LT:Options", ltOptions);

            IWebDriver driver = new RemoteWebDriver(
                new Uri("https://hub.lambdatest.com/wd/hub"), options);
            return driver;
        }
    }
}
