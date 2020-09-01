using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using OpenQA.Selenium.Appium.iOS;
using NUnit.Framework;

namespace csharp_appium_first_browserstack_ios
{
    class Program
    {
        static void Main(string[] args)
        {
            AppiumOptions options = new AppiumOptions();
        

            // Set your BrowserStack access credentials
            options.AddAdditionalCapability("browserstack.user", "YOUR_USERNAME");
            options.AddAdditionalCapability("browserstack.key", "YOUR_ACCESS_KEY");

            // Set URL of the application under test
            options.AddAdditionalCapability("app", "bs://<app-id>");

            // Specify device and os_version
            options.AddAdditionalCapability("device", "iPhone 11 Pro");
            options.AddAdditionalCapability("os_version", "13");

            // Specify the platformName
            options.PlatformName = "iOS";

            // Set other BrowserStack capabilities
            options.AddAdditionalCapability("project", "First CSharp project");
            options.AddAdditionalCapability("build", "CSharp iOS");
            options.AddAdditionalCapability("name", "first_test");

            // Initialize the remote Webdriver using BrowserStack remote URL
            // and desired capabilities defined above
            IOSDriver<IOSElement> driver = new IOSDriver<IOSElement>(
                new Uri("http://hub-cloud.browserstack.com/wd/hub"), options);

            // Test case for the BrowserStack sample iOS app. 
            // If you have uploaded your app, update the test case here.
            IOSElement textButton = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Text Button"))
            );
            textButton.Click();
            IOSElement textInput = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Text Input"))
            );
            textInput.SendKeys("hello@browserstack.com" + "\n");

            IOSElement textOutput = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Text Output"))
            );

            Assert.AreEqual(textOutput.Text, "hello@browserstack.com");
            driver.Quit();

        }
    }
}
