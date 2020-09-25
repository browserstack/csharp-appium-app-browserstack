using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using BrowserStack;
using System.Runtime.InteropServices;

namespace csharp_appium_local_browserstack_ios
{


    class Program
    {
        readonly static string userName = "YOUR_USERNAME";
        readonly static string accessKey = "YOUR_ACCESS_KEY";
        static void Main(string[] args)
        {
            Local browserStackLocal;

            AppiumOptions appiumOptions = new AppiumOptions();
            // Set your BrowserStack access credentials
            appiumOptions.AddAdditionalCapability("browserstack.user", userName);
            appiumOptions.AddAdditionalCapability("browserstack.key", accessKey);


            // Set URL of the application under test
            appiumOptions.AddAdditionalCapability("app", "bs://<app_id>");

            // Specify device and os_version
            appiumOptions.AddAdditionalCapability("device", "iPhone 11 Pro");
            appiumOptions.AddAdditionalCapability("os_version", "13");

            // Set browserstack.local capability as true
            appiumOptions.AddAdditionalCapability("browserstack.local", "true");

            // Specify the platform name
            appiumOptions.PlatformName = "iOS";

            // Set other BrowserStack capabilities
            appiumOptions.AddAdditionalCapability("project", "First CSharp project");
            appiumOptions.AddAdditionalCapability("build", "CSharp iOS local");
            appiumOptions.AddAdditionalCapability("name", "local_test");



            // if the platform is Windows, enable local testing fropm within the test
            // for Mac and GNU/Linux, run the local binary manually to enable local testing (see the docs)
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                    && appiumOptions.ToCapabilities().HasCapability("browserstack.local")
                    && appiumOptions.ToCapabilities().HasCapability("browserstack.local").ToString() == "true")
            {
                browserStackLocal = new Local();
                List<KeyValuePair<string, string>> bsLocalArgs = new List<KeyValuePair<string, string>>() {
                        new KeyValuePair<string, string>("key", accessKey)
                };
                browserStackLocal.start(bsLocalArgs);
            }


            // Initialize the remote Webdriver using BrowserStack remote URL
            // and desired capabilities defined above
            IOSDriver<IOSElement> driver = new IOSDriver<IOSElement>(new Uri("http://hub-cloud.browserstack.com/wd/hub"), appiumOptions);

            //Test case for sample iOS Local app.
            IOSElement testButton = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("TestBrowserStackLocal"))
            );
            testButton.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(driver.FindElement(MobileBy.AccessibilityId("ResultBrowserStackLocal")), "Response is: Up and running"));
            IOSElement resultElement = (IOSElement)driver.FindElement(MobileBy.AccessibilityId("ResultBrowserStackLocal"));

            Console.WriteLine(resultElement.Text);

            driver.Quit();


        }
    }
}
