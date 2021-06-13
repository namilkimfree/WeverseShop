using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using WeverseShop.Base;

namespace WeverseShop.Pages
{
    /// <summary>
    /// Artist 설정과 상점 설정
    /// BTS && GLOBAL
    /// </summary>
    public class ArtistAndShopPage : BasePage
    {

        [FindsByAndroidUIAutomator(ID = "nameTextView")]

        private IList<AppiumWebElement> artistMobileElements;

        [FindsByAndroidUIAutomator(ID = "confirmTextView")]
        private IMobileElement<AppiumWebElement> _confirmElement;

        [FindsByAndroidUIAutomator(ID = "scrollLayout")]
        private IMobileElement<AppiumWebElement> _scrollElement;
        

        public void WaitUntilPageLoads()
        {
            Helper.WaitFor(() => _confirmElement.Displayed);
        }


        public void ClickArtist(string artistName)
        {
            var condition = ((Func<bool>) (() =>
            {
                var artists = Manager.AppiumDriver.FindElementsById("nameTextView");

                var findArtist =
                    artists.FirstOrDefault(artist => artist.Text == artistName);

                if (findArtist == null)
                    return false;

                findArtist.Click();

                return true;
            }));

            Helper.ScrollDownUntilCondition(condition, _scrollElement);
        }

        public void ClickShop(string shopName)
        {
        
            var shop =
                Helper.WaitFor(() => Driver.FindElementByXPath($"//android.widget.TextView[@text='{shopName}']"));

            shop.Click();
        }

        public CurrencyPage ClickConfirm()
        {
            _confirmElement.Click();

            var currencyPage = new CurrencyPage();
            return currencyPage;
        }

    }
}