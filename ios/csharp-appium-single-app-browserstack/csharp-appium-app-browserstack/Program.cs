using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace BrowserStackAppiumSingleTest
{

    class MainClass
    {

        readonly static string userName = "BROWSERSTACK_USERNAME";
        readonly static string accessKey = "BROWSERSTACK_ACCESS_KEY";


        public static void Main(string[] args)
        {
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability("browserstack.user", userName);
            caps.SetCapability("browserstack.key", accessKey);

            caps.SetCapability("device", "iPhone 7");
            caps.SetCapability("app", "bs://<hashed app-id>");
            IOSDriver<IOSElement> driver = new IOSDriver<IOSElement> (new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            IOSElement textButton = (IOSElement) new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Text Button"))
            );
            textButton.Click();
            IOSElement textInput = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Text Input"))
            );
            textInput.SendKeys("hello@browserstack.com");

            IOSElement textOutput = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Text Output"))
            );

            Assert.AreEqual(textOutput.Text,"hello@browserstack.com");
            driver.Quit();
        }
    }
}
