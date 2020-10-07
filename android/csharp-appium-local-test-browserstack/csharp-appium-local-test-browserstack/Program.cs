using System;
using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using BrowserStack;
using System.Runtime.InteropServices;

namespace csharp_appium_local_test_browserstack
{
    class Program
    {
        readonly static string userName = "YOUR_USERNAME";
        readonly static string accessKey = "YOUR_ACCESS_KEY";
 
        static void Main(string[] args)
        {
            Local browserStackLocal=null;

        AppiumOptions appiumOptions = new AppiumOptions();
            // Set your BrowserStack access credentials
            appiumOptions.AddAdditionalCapability("browserstack.user", userName);
            appiumOptions.AddAdditionalCapability("browserstack.key", accessKey);


            // Set URL of the application under test
            appiumOptions.AddAdditionalCapability("app", "bs://<app-id>");

            // Specify device and os_version
            appiumOptions.AddAdditionalCapability("device", "Google Pixel 3");
            appiumOptions.AddAdditionalCapability("os_version", "9.0");

            appiumOptions.AddAdditionalCapability("browserstack.local", "true");

            // Specify the platform name
            appiumOptions.PlatformName = "Android";

            // Set other BrowserStack capabilities
            appiumOptions.AddAdditionalCapability("project", "First CSharp project");
            appiumOptions.AddAdditionalCapability("build", "CSharp Android local");
            appiumOptions.AddAdditionalCapability("name", "local_test");


            // if the platform is Windows, enable local testing fropm within the test
            // for Mac and GNU/Linux, run the local binary manually to enable local testing (see the docs)
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                    && appiumOptions.ToCapabilities().HasCapability("browserstack.local")
                    && appiumOptions.ToCapabilities().GetCapability("browserstack.local").ToString() == "true")
            {
                browserStackLocal = new Local();
                List<KeyValuePair<string, string>> bsLocalArgs = new List<KeyValuePair<string, string>>() {
                        new KeyValuePair<string, string>("key", accessKey)
                };
                browserStackLocal.start(bsLocalArgs);
            }


            // Initialize the remote Webdriver using BrowserStack remote URL
            // and desired capabilities defined above
            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), appiumOptions);

            // Test case for the BrowserStack sample Android Local app.
            // If you have uploaded your app, update the test case here.
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.Id("com.example.android.basicnetworking:id/test_action"))
            );
            searchElement.Click();
            AndroidElement insertTextElement = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.ClassName("android.widget.TextView"))
            );

            AndroidElement testElement = null;

            IReadOnlyList<AndroidElement> allTextViewElements = driver.FindElementsByClassName("android.widget.TextView");
            System.Threading.Thread.Sleep(5000);
            foreach (AndroidElement textElement in allTextViewElements)
            {
                if (textElement.Text.Contains("The active connection is"))
                {
                    testElement = textElement;
                }
            }

            Console.WriteLine(testElement.Text);
            // Invoke driver.quit() after the test is done to indicate the test is completed.
            driver.Quit();

            // Stop the BrowserStack Local Binary.
            if(browserStackLocal != null)
            {
                browserStackLocal.stop();
            }

        }
    }
}
