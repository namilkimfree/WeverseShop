using System;
using System.IO;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;
using WeverseShop.Config;
using WeverseShop.Manager;

namespace WeverseShop.Hooks
{
    [Binding]
    public class HookInitialize
    {
        /// <summary>
        /// Appium 설정
        /// </summary>
        private static AppiumManager _appiumManager;


        /// <summary>
        /// Test 실행하기 전,
        /// Config 설정
        /// Appium Local service 실행
        /// Appium Manager 실행
        /// </summary>
        [BeforeTestRun]
        public static void InitializeSetting()
        {
            ConfigBinder.ConfigInstance.ServiceConfiguration();

            _appiumManager = ConfigBinder.ConfigInstance.GetService<AppiumManager>();

            _appiumManager.StartServer();
            _appiumManager.InitializeAppiumDriver();

        }
 


        /// <summary>
        /// 테스트 종료시
        /// App 종료
        /// Driver 종료
        /// </summary>
        [AfterTestRun]
        public static void TearDownReport()
        {
            _appiumManager.AppiumDriver.CloseApp();
            _appiumManager.AppiumDriver.Quit();
            _appiumManager.CloseServer();
        }
    }
}