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

        readonly static string userName = Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME");
        readonly static string accessKey = Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY");


        public static void Main(string[] args)
        {
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability("browserstack.user", userName);
            caps.SetCapability("browserstack.key", accessKey);

            caps.SetCapability("realMobile", true);
            caps.SetCapability("automationName", "XCUITest");
            caps.SetCapability("device", "iPhone 7");
            caps.SetCapability("app", "bs://<hashed app-id>");
            IOSDriver<IOSElement> driver = new IOSDriver<IOSElement> (new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            IOSElement loginButton = (IOSElement) new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Log In"))
            );
            loginButton.Click();
            IOSElement emailTextField = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Email address"))
            );
            emailTextField.SendKeys("hello@browserstack.com");

            driver.FindElementByAccessibilityId("Next").Click();
            System.Threading.Thread.Sleep(5000);


            IReadOnlyList<IOSElement> textElements = driver.FindElementsByXPath("//XCUIElementTypeStaticText");

            String matchedString = "";
            foreach(IOSElement textElement in textElements)
            {
                String textContent = textElement.Text;
                if (textContent.Contains("not registered"))
                {
                    matchedString = textContent;
                }
            }

            Console.WriteLine(matchedString);
            driver.Quit();
        }
    }
}
