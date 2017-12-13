using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
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

            caps.SetCapability("device", "Google Pixel");
            caps.SetCapability("browserstack.local", true);
            caps.SetCapability("app", "bs://<hashed app-id>");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            AndroidElement searchElement = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                ExpectedConditions.ElementToBeClickable(MobileBy.Id("com.example.android.basicnetworking:id/test_action"))
            );
            searchElement.Click();
            AndroidElement insertTextElement = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                ExpectedConditions.ElementToBeClickable(MobileBy.ClassName("android.widget.TextView"))
            );

            AndroidElement testElement = null;

            IReadOnlyList<AndroidElement> allTextViewElements =  driver.FindElementsByClassName("android.widget.TextView");
            System.Threading.Thread.Sleep(5000);
            foreach (AndroidElement textElement in allTextViewElements)
            {
                if (textElement.Text.Contains("The active connection is"))
                {
                    testElement = textElement;
                }
            }

            Console.WriteLine(testElement.Text);

            driver.Quit();
            local.stop();
        }
    }
}
