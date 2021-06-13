using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using WeverseShop.Base;
using WeverseShop.Model;

namespace WeverseShop.Pages
{
    /// <summary>
    /// 언어 설정 Page
    /// </summary>
    public class LanguagePage : BasePage
    {
        [FindsByAndroidUIAutomator(ID = "nameTextView")]
        private IList<AppiumWebElement> _langElements;
        
        [FindsByAndroidUIAutomator(ID = "confirmTextView")]
        private IMobileElement<AppiumWebElement> _confirmElement;

        /// <summary>
        /// 특정 언어를 받아와서
        /// 해당 언어 클릭
        /// </summary>
        /// <param name="language"></param>
        public void ClickLanguage(Language language)
        {
            var langElement =
                _langElements.FirstOrDefault(lang => lang.Text == language.ToString());

            langElement.Click();
        }

        public void WaitUntilPageLoads()
        {
            Helper.WaitFor(() => _confirmElement.Displayed);
        }

        /// <summary>
        /// 확인 버튼 클릭
        /// </summary>
        /// <returns></returns>
        public ArtistAndShopPage ClickConfirm()
        {
            _confirmElement.Click();
            var artistPage = new ArtistAndShopPage();

            return artistPage;
        }

    }
}