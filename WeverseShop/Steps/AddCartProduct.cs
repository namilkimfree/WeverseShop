using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using WeverseShop.Base;
using WeverseShop.Pages;
using WeverseShop.Pages.Shop;

namespace WeverseShop.Steps
{
    [Binding]
    public sealed class AddCartProduct : BaseStep
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public AddCartProduct(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Given(@"click cateogry '(.*)'")]
        public void GivenClickCateogry(string category)
        {
            var homePage = new HomePage();

            CurrentBasePage = homePage;

            homePage.ClickCategory(category);
        }

        [When(@"click any product")]
        public void WhenClickAnyProduct()
        {
            var homePage = CurrentBasePage as HomePage;

            CurrentBasePage = homePage.RandomProductClick();
        }

        [When(@"add to cart for product")]
        public void WhenAddToCartForProduct()
        {
            var productDetailPage = CurrentBasePage as ProductDetailPage;

            productDetailPage.WaitUntilPageLoads();

            var productName = productDetailPage.GetProductName();

            _scenarioContext.Set(productName);

            CurrentBasePage = productDetailPage.ClickAddCart();
        }

        [When(@"add to cart click")]
        public void WhenAddToCartClick()
        {
            var optionPage = CurrentBasePage as OptionPage;

            optionPage.RandomOptionClick();

            CurrentBasePage = optionPage.ClickAddCart();
        }

        [When(@"click move to cart after open popup")]
        public void WhenClickMoveToCartAfterOpenPopup()
        {
            var addCartCompletePopupPage = CurrentBasePage as AddCartCompletePopupPage;

            CurrentBasePage = addCartCompletePopupPage.ClickGoToCart();
        }

        [Then(@"check the items added to the shopping cart")]
        public void ThenCheckTheItemsAddedToTheShoppingCart()
        {
            var cartPage = CurrentBasePage as CartPage;

            var productName = _scenarioContext.Get<string>();

            cartPage.AssertEqualsProductName(productName);
        }
    }
}
