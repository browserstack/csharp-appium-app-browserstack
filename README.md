# csharp-appium-app-browserstack

This repository demonstrates how to run Appium CSharp tests on BrowserStack App Automate.

## Setup

### Requirements

1. Visual Studio 2019

    - If not installed, download and install Visual Studio 2019 from [here](https://visualstudio.microsoft.com/vs/)

## Getting Started

Getting Started with Appium tests in CSharp on BrowserStack couldn't be easier!

### Run your first test :

**1. Upoad your Android or iOS App**

Upload your Android app (.apk or .aab file) or iOS app (.ipa file) to BrowserStack servers using our REST API. Here is an example cURL request :

```curl
curl -u "YOUR_USERNAME:YOUR_ACCESS_KEY" \
-X POST "https://api-cloud.browserstack.com/app-automate/upload" \
-F "file=@/path/to/apk/file"
```

Ensure that @ symbol is prepended to the file path in the above request. Please note the `app_url` value returned in the API response. We will use this to set the application under test while configuring the test later on.

**Note**: If you do not have an .apk or .ipa file and are looking to simply try App Automate, you can download and test using our [sample Android app](https://www.browserstack.com/app-automate/sample-apps/android/WikipediaSample.apk) or [sample iOS app](https://www.browserstack.com/app-automate/sample-apps/ios/BStackSampleApp.ipa).

**2. Congigure and run your first test**

-  For Android tests :

    - Open and build the Visual Studio project `csharp-appium-first-test-browserstack` within `android` folder,
 
 Or,

-  For iOS tests :

    - Open and build the Visual Studio project `csharp-appium-first-browserstack-ios` within `ios` folder
    
- Open `Program.cs` file in the opened project

- Replace `YOUR_USERNAME` & `YOUR_ACCESS_KEY` with your BrowserStack access credentials

- Replace `bs://<app-id>` wkth the URL obtained in the app upload step

- Set the device and OS version

- If you have uploaded your own app update the test case

- Run the project

- You can access the test execution results, and debugging information such as video recording, network logs on [App Automate dashboard](https://app-automate.browserstack.com/dashboard)

---

### **Use Local testing for apps that access resources hosted in development or testing environments :**

**1. Upload your Android or iOS App**

Upload your Android app (.apk or .aab file) or iOS app (.ipa file) that access resources hosted on your internal or test environments to BrowserStack servers using our REST API. Here is an example cURL request :

```
curl -u "YOUR_USERNAME:YOUR_ACCESS_KEY" \
-X POST "https://api-cloud.browserstack.com/app-automate/upload" \
-F "file=@/path/to/apk/file"
```

Ensure that @ symbol is prepended to the file path in the above request. Please note the `app_url` value returned in the API response. We will use this to set the application under test while configuring the test later on.

**Note**: If you do not have an .apk or .ipa file and are looking to simply try App Automate, you can download and test using our [sample Android Local app](https://www.browserstack.com/app-automate/sample-apps/android/LocalSample.apk) or [sample iOS Local app](https://www.browserstack.com/app-automate/sample-apps/ios/LocalSample.ipa).

**2. Congigure and run your local test**

-  For Android tests :

    - Open and build the Visual Studio project `csharp-appium-local-test-browserstack` within `android` folder,
 
 Or,

-  For iOS tests :

    - Open and build the Visual Studio project `csharp-appium-local-browserstack-ios` within `ios` folder
    
- Open `Program.cs` file in the opened project

- Replace `YOUR_USERNAME` & `YOUR_ACCESS_KEY` with your BrowserStack access credentials

- Replace `bs://<app-id>` wkth the URL obtained in the app upload step

- Set the device and OS version

- Ensure that `browserstack.local` capability is set to `true`. Within the test script, there is code snippet that automatically starts and stops Local Testing connection using BrowserStack’s CSharp binding for BrowserStack Local. 

- If you have uploaded your own app update the test case

- Run the project

- You can access the test execution results, and debugging information such as video recording, network logs on [App Automate dashboard](https://app-automate.browserstack.com/dashboard)

**Note**: If you are running Local test on Mac or GNU/Linux, you need to establish a Local Testing connection through your command-line interface by following the these steps:
 1. Download binary appropriate to your system: 
    - [OS X (10.7 and above)](https://www.browserstack.com/browserstack-local/BrowserStackLocal-darwin-x64.zip)
    - [Linux 32-bit](https://www.browserstack.com/browserstack-local/BrowserStackLocal-linux-ia32.zip)
    - [Linux 64-bit](https://www.browserstack.com/browserstack-local/BrowserStackLocal-linux-x64.zip)
 2. Run the binary using `./BrowserStackLocal --key <YOUR_ACCESS_KEY>`

## Integration with other CSharp frameworks

For other CSharp frameworks samples, refer to following repositories :

- [NUnit](https://github.com/browserstack/nunit-appium-app-browserstack)

Note: For other test frameworks supported by App-Automate refer our [Developer documentation](https://www.browserstack.com/docs/)

## Getting Help

If you are running into any issues or have any queries, please check [Browserstack Support page](https://www.browserstack.com/support/app-automate) or [get in touch with us](https://www.browserstack.com/contact?ref=help).
