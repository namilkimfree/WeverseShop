using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using WeverseShop.Base;

namespace WeverseShop.Pages.Shop
{
    /// <summary>
    /// 장바구니에 담기전 옵션 설정 Page
    /// </summary>
    public class OptionPage : BasePage
    {
        [FindsByAndroidUIAutomator(XPath = "//*[@resource-id='co.benx.weply:id/titleTextView']")]
        private IList<AppiumWebElement> _scrollMobileElement;

        [FindsByAndroidUIAutomator(ID = "footerLeftTextView")]
        private IMobileElement<AppiumWebElement> _addCartMobileElement;


        /// <summary>
        /// Option 리스트 중에 한개를 가져오고
        /// 해당 Option 클릭
        /// </summary>
        public void RandomOptionClick()
        {
            var random = _scrollMobileElement.FirstOrDefault();

            random.Click();
        }


        /// <summary>
        /// 장바구니 추가 버튼 클릭
        /// </summary>
        /// <returns></returns>
        public AddCartCompletePopupPage ClickAddCart()
        {
            _addCartMobileElement.Click();

            var addCartCompletePopupPage = new AddCartCompletePopupPage();
            return addCartCompletePopupPage;
        }



        


    }
}