using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using WeverseShop.Base;

namespace WeverseShop.Pages.Shop
{
    /// <summary>
    /// 장바구니 추가 완료시
    /// Popup Page
    /// </summary>
    public class AddCartCompletePopupPage : BasePage
    {
        [FindsByAndroidUIAutomator(ID = "gotoCartTextView")]
        private IMobileElement<AppiumWebElement> _goToCartMobileElement;
        
        /// <summary>
        /// 장바구니로 이동
        /// 버튼 클릭
        /// </summary>
        /// <returns></returns>
        public CartPage ClickGoToCart()
        {
            _goToCartMobileElement.Click();

            var cartPage = new CartPage();

            return cartPage;
        }
    }
}