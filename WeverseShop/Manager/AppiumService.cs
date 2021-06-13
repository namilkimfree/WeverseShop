using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenQA.Selenium.Appium.Service;

namespace WeverseShop.Manager
{
    public class AppiumService
    {
        private AppiumLocalService appiumLocalService;

        private const string _fileName = "ServerLog";
        
        public AppiumLocalService StartService()
        {
            appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().WithLogFile(new FileInfo(_fileName)).Build();
            appiumLocalService.Start();

            return appiumLocalService;
        }

        public AppiumLocalService StartServiceWithPort(int port)
        {
            appiumLocalService = new AppiumServiceBuilder().
                UsingPort(port).WithLogFile(new FileInfo(_fileName)).Build();
            appiumLocalService.Start();

            return appiumLocalService;
        }

        public AppiumLocalService StartServiceWithPortAndLog(int port, string fileName)
        {
            appiumLocalService = new AppiumServiceBuilder().
                UsingPort(port).WithLogFile(new FileInfo(fileName)).Build();
            appiumLocalService.Start();

            return appiumLocalService;
        }

        public void CloseService()
        {
            appiumLocalService.Dispose();
        }

        public AppiumLocalService GetAppiumLocalService() => appiumLocalService;
        public Uri GetServerUri() => appiumLocalService.ServiceUrl;

    }
}
