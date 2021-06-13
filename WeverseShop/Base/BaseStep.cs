using OpenQA.Selenium.Appium;
using WeverseShop.Config;
using WeverseShop.Manager;

namespace WeverseShop.Base
{
    /// <summary>
    /// TestStep에서
    /// 현재 Page를 관리 용
    /// </summary>
    public class BaseStep : Base
    {
        protected BasePage CurrentBasePage { get; set; }

    }
}