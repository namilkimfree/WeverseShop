using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using WeverseShop.Base;

namespace WeverseShop.Pages
{
    /// <summary>
    /// 통화 설정 Page
    /// </summary>
    public class CurrencyPage : BasePage
    {
        [FindsByAndroidUIAutomator(ID = "confirmTextView")]
        private IMobileElement<AppiumWebElement> _confirmElement;

        [FindsByAndroidUIAutomator(ID = "nameTextView")]
        private IList<AppiumWebElement> _currencyElements;

        public void WaitUntilPageLoads()
        {
            Helper.WaitFor(() => _confirmElement.Displayed);
        }

        public void ClickCurrency(string currencyName)
        {
            var currencyElement =
                _currencyElements.FirstOrDefault(currency => currency.Text == currencyName);

            currencyElement.Click();
        }

        public HomePage ClickConfirm()
        {
            _confirmElement.Click();
            var homePage = new HomePage();

            return homePage;
        }

    }
}