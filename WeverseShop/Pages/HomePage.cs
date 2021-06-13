using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using WeverseShop.Base;
using WeverseShop.Pages.My;
using WeverseShop.Pages.Shop;

namespace WeverseShop.Pages
{
    /// <summary>
    /// Home Page Default Page
    /// </summary>
    public class HomePage : BasePage
    {
        [FindsByAndroidUIAutomator(ID = "shopTextView")]
        private IMobileElement<AppiumWebElement> _shopMobileElement;

        [FindsByAndroidUIAutomator(ID = "myTextView")]
        private IMobileElement<AppiumWebElement> _myMobileElement;

        [FindsByAndroidUIAutomator(ID = "categoryTabLayout")]
        private IMobileElement<AppiumWebElement> _categoryTabMobileElement;

        [FindsByAndroidUIAutomator(ID = "scrollView")]
        private IMobileElement<AppiumWebElement> _scrollMobileElement;
        

        public void WaitUntilPageLoads()
        {
            Helper.WaitFor(() => _shopMobileElement.Displayed);
        }

        /// <summary>
        /// Home 스크린의
        /// footer Tab중의 My Tab 클릭
        /// </summary>
        /// <returns></returns>
        public MyPage ClickMyPageTab()
        {
            _myMobileElement.Click();

            var myPage = new MyPage();
            return myPage;
        }

        /// <summary>
        /// Home 스크린의
        /// 상품 카테고리 클릭
        /// </summary>
        /// <param name="categoryName"></param>
        public void ClickCategory(string categoryName)
        {
            var condition = ((Func<bool>)(() =>
            {
                var findCategory = Manager.AppiumDriver.FindElementByAccessibilityId(categoryName);

                if (findCategory == null)
                    return false;

                findCategory.Click();

                return true;
            }));

            Helper.ScrollHorizonUntilCondition(condition, _categoryTabMobileElement);
        }

        /// <summary>
        /// Home 스크린의
        /// 임의 상품 클릭
        /// </summary>
        /// <returns></returns>
        public ProductDetailPage RandomProductClick()
        {
            var condition = ((Func<bool>)(() =>
            {
                var randomProduct = Manager.AppiumDriver.FindElementById("saleImageView");

                if (randomProduct == null)
                    return false;

                randomProduct.Click();

                return true;
            }));

            Helper.ScrollDownUntilCondition(condition, _scrollMobileElement);

            var productDetailPage = new ProductDetailPage();

            return productDetailPage;
        }

    }
}