using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Support.UI;
using WeverseShop.Config;

namespace WeverseShop.Manager
{
    public class AppiumManager
    {
        private readonly AppiumService _appiumService;
        private readonly GlobalConfig _config;
        public AppiumDriver<AppiumWebElement> AppiumDriver { get; private set; }
        public GlobalConfig Config => _config;


        public AppiumManager(AppiumService appiumService,GlobalConfig config)
        {
            _appiumService = appiumService;
            _config = config;
        }


        /// <summary>
        /// local server start
        /// </summary>
        public void StartServer() => _appiumService.StartService();

        /// <summary>
        /// local server close
        /// </summary>
        public void CloseServer() => _appiumService.CloseService();


        /// <summary>
        /// appium dirver initialize
        /// </summary>
        public void InitializeAppiumDriver()
        {
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, _config.AutomationName);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, _config.DeviceName);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, _config.PlatformName);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.NoReset, true);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, _config.App);


            AppiumDriver = new AndroidDriver<AppiumWebElement>(_appiumService.GetServerUri(), appiumOptions,
                TimeSpan.FromMilliseconds(_config.TimeoutMilliseconds));
        }
    }
}