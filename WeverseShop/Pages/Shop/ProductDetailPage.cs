using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using WeverseShop.Base;

namespace WeverseShop.Pages.Shop
{
    /// <summary>
    /// 상품 상세 정보
    /// </summary>
    public class ProductDetailPage : BasePage
    {
        [FindsByAndroidUIAutomator(ID = "footerLeftTextView")]
        private IMobileElement<AppiumWebElement> _addCartMobileElement;


        [FindsByAndroidUIAutomator(ID = "scrollView")]
        private IMobileElement<AppiumWebElement> _scrollMobileElement;
        
        /// <summary>
        /// displayed 대기
        /// </summary>
        public void WaitUntilPageLoads()
        {
            Helper.WaitFor(() => _addCartMobileElement.Displayed);
        }

        /// <summary>
        /// 현재 선택한 productName 가져오기 위함
        /// 장바구니에 담긴 상품과 비교 하기 위함
        /// </summary>
        /// <returns></returns>
        public string GetProductName()
        {
            var condition = ((Func<IMobileElement<AppiumWebElement>>)(() =>
            {
                var productNamElement = Manager.AppiumDriver.FindElementById("nameTextView");

                return productNamElement;
            }));

            var productNameElement = 
                Helper.ScrollDownUntilCondition(condition, _scrollMobileElement);

            return productNameElement.Text;
        }


        /// <summary>
        /// 장바구니 추가 버튼 클릭
        /// </summary>
        /// <returns></returns>
        public OptionPage ClickAddCart()
        {
            _addCartMobileElement.Click();

            var optionPage = new OptionPage();

            return optionPage;
        }
    }
}