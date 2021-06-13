using OpenQA.Selenium.Appium;
using WeverseShop.Config;
using WeverseShop.Manager;

namespace WeverseShop.Base
{
    /// <summary>
    /// Manager Class
    /// Helper Class
    /// Driver를 가지고 있는 베이스 클래스
    /// </summary>
    public class Base
    {
        protected AppiumManager Manager => ConfigBinder.ConfigInstance.GetService<AppiumManager>();
        protected AppiumHelper Helper => ConfigBinder.ConfigInstance.GetService<AppiumHelper>();
        protected AppiumDriver<AppiumWebElement> Driver => Manager.AppiumDriver;
    }
}