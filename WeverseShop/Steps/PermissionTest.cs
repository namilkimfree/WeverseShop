using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using WeverseShop.Base;
using WeverseShop.Model;
using WeverseShop.Pages;

namespace WeverseShop.Steps
{
    [Binding]
    public sealed class PermissionTest : BaseStep
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public PermissionTest(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"loading permission activity")]
        public void GivenLoadingPermissionActivity()
        {
            
            var permissionPage = new PermissionPage();
            CurrentBasePage = permissionPage;
            permissionPage.WaitUntilPageLoads();

        }

        [Given(@"confirm permission")]
        public void GivenConfirmPermission()
        {
            var permissionPage =  CurrentBasePage as PermissionPage;

            CurrentBasePage = permissionPage.ConfirmPermission();
        }

        [When(@"navigated language choice activity")]
        public void WhenNavigatedLanguageChoiceActivity()
        {
            var languagePage = CurrentBasePage as LanguagePage;

            languagePage.WaitUntilPageLoads();

        }

        [When(@"'(.*)' language click")]
        public void WhenKoreaLanguageClick(Language lang)
        {
            var languagePage = CurrentBasePage as LanguagePage;
            languagePage.ClickLanguage(lang);
        }

        [When(@"next click")]
        public void WhenNextClick()
        {
            var languagePage = CurrentBasePage as LanguagePage;
            CurrentBasePage = languagePage.ClickConfirm();
        }

        [When(@"naviagted artist & shop choice activity")]
        public void WhenNaviagtedArtistShopChoiceActivity()
        {
            var artistPage = CurrentBasePage as ArtistAndShopPage;
            artistPage.WaitUntilPageLoads();
        }

        [When(@"'(.*)' artist click")]
        public void WhenArtistClick(string artist)
        {
            var artistPage = CurrentBasePage as ArtistAndShopPage;
            artistPage.ClickArtist(artist);
        }

        [When(@"'(.*)' shop click")]
        public void WhenShopClick(string shop)
        {
            var artistPage = CurrentBasePage as ArtistAndShopPage;
            artistPage.ClickShop(shop);
        }

        [When(@"confirm artist click")]
        public void WhenConfirmClick()
        {
            var artistPage = CurrentBasePage as ArtistAndShopPage;
            CurrentBasePage = artistPage.ClickConfirm();
        }

        [When(@"naviagted currency choice activity")]
        public void WhenNaviagtedCurrencyChoiceActivity()
        {
            var currencyPage= CurrentBasePage as CurrencyPage;
            currencyPage.WaitUntilPageLoads();
        }

        [When(@"'(.*)' currency click")]
        public void WhenCurrencyClick(string currency)
        {
            var currencyPage = CurrentBasePage as CurrencyPage;
            currencyPage.ClickCurrency(currency);
        }

        [When(@"confirm curreny click")]
        public void WhenConfirmCurrenyClick()
        {
            var currencyPage = CurrentBasePage as CurrencyPage;
            CurrentBasePage = currencyPage.ClickConfirm();
        }

        [Then(@"loaded shop activity")]
        public void ThenLoadedShopActivity()
        {
            var homePage = CurrentBasePage as HomePage;
            homePage.WaitUntilPageLoads();
        }

       

    }
}
