using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
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
            caps.SetCapability("device", "Google Pixel");
            caps.SetCapability("app", "bs://<hashed app-id>");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(driver,TimeSpan.FromSeconds(30)).Until(
                ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Search Wikipedia"))
            );
            searchElement.Click();
            AndroidElement insertTextElement = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                ExpectedConditions.ElementToBeClickable(MobileBy.Id("org.wikipedia.alpha:id/search_src_text"))
            );
            insertTextElement.SendKeys("BrowserStack");
            System.Threading.Thread.Sleep(5000);

            IReadOnlyList<AndroidElement> allTextViewElements =  driver.FindElementsByClassName("android.widget.TextView");
            Console.WriteLine(allTextViewElements.Count() > 0);

            driver.Quit();
        }
    }
}
