using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using BrowserStack;

namespace BrowserStackAppiumLocalTest
{

    class MainClass
    {

        readonly static string userName = "BROWSERSTACK_USERNAME";
        readonly static string accessKey = "BROWSERSTACK_ACCESS_KEY";


        public static void Main(string[] args)
        {
            Local local = new Local();

            List<KeyValuePair<string, string>> options = new List<KeyValuePair<string, string>>() {
               new KeyValuePair<string, string>("key", accessKey)
            };

            local.start(options);

            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability("browserstack.user", userName);
            caps.SetCapability("browserstack.key", accessKey);

            caps.SetCapability("device", "iPhone 7");
            caps.SetCapability("browserstack.local", true);
            caps.SetCapability("app", "bs://<hashed app-id>");

            IOSDriver<IOSElement> driver = new IOSDriver<IOSElement>(new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            IOSElement testButton = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("TestBrowserStackLocal"))
            );
            testButton.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(driver.FindElement(MobileBy.AccessibilityId("ResultBrowserStackLocal")), "Response is: Up and running"));
            IOSElement resultElement = (IOSElement)driver.FindElement(MobileBy.AccessibilityId("ResultBrowserStackLocal"));

            Console.WriteLine(resultElement.Text);

            driver.Quit();
            local.stop();
        }
    }
}
