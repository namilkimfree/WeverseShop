using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using WeverseShop.Base;

namespace WeverseShop.Pages.Shop
{
    /// <summary>
    /// 장바구니 Page
    /// </summary>
    public class CartPage : BasePage
    {
        [FindsByAndroidUIAutomator(ID = "nameTextView")]
        private IMobileElement<AppiumWebElement> _productNamMobileElement;


        /// <summary>
        /// 실제 장바구니에 담긴
        /// 상품과 기존에 선택한 상품이 동일한지
        /// 상품 이름으로 비교
        /// </summary>
        /// <param name="assertProductName"></param>
        public void AssertEqualsProductName(string assertProductName)
        {
            var productName = _productNamMobileElement.Text;

            Assert.That(productName == assertProductName);
        }
        
    }
}