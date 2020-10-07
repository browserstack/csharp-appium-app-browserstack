using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace csharp_appium_first_test_browserstack
{
    class Program
    {
        static void Main(string[] args)
        {
            AppiumOptions caps = new AppiumOptions();

            // Set your BrowserStack access credentials
            caps.AddAdditionalCapability("browserstack.user", "YOUR_USERNAME");
            caps.AddAdditionalCapability("browserstack.key", "YOUR_ACCESS_KEY");

            // Set URL of the application under test
            caps.AddAdditionalCapability("app", "bs://<app-id>");

            // Specify device and os_version
            caps.AddAdditionalCapability("device", "Google Pixel 3");
            caps.AddAdditionalCapability("os_version", "9.0");

            // Specify the platform name
            caps.PlatformName = "Android";

            // Set other BrowserStack capabilities
            caps.AddAdditionalCapability("project", "First CSharp project");
            caps.AddAdditionalCapability("build", "CSharp Android");
            caps.AddAdditionalCapability("name", "first_test");


            // Initialize the remote Webdriver using BrowserStack remote URL
            // and desired capabilities defined above
            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            // Test case for the BrowserStack sample Android app. 
            // If you have uploaded your app, update the test case here.
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.AccessibilityId("Search Wikipedia"))
            );
            searchElement.Click();
            AndroidElement insertTextElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.Id("org.wikipedia.alpha:id/search_src_text"))
            );
            insertTextElement.SendKeys("BrowserStack");
            System.Threading.Thread.Sleep(5000);

            IReadOnlyList<AndroidElement> allTextViewElements =
                driver.FindElementsByClassName("android.widget.TextView");
            Console.WriteLine(allTextViewElements.Count > 0);

            // Invoke driver.quit() after the test is done to indicate that the test is completed.
            driver.Quit();
        }
    }
}
