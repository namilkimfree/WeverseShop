using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using WeverseShop.Base;

namespace WeverseShop.Pages
{
    /// <summary>
    /// 권한 설정
    /// </summary>
    public class PermissionPage : BasePage
    {
        [FindsByAndroidUIAutomator(ID = "confirmTextView")]
        private IMobileElement<AppiumWebElement> _confirmElement;
        

        public void WaitUntilPageLoads()
        {
            Helper.WaitFor(() => _confirmElement.Displayed);
        }

        /// <summary>
        /// 권한 허용 버튼 클릭
        /// </summary>
        /// <returns></returns>
        public LanguagePage ConfirmPermission()
        {
            _confirmElement.Click();

            var languagePage = new LanguagePage();
            return languagePage;
        }


    }
}