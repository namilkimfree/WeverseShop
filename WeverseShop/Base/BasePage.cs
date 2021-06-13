using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.PageObjects;
using SeleniumExtras.PageObjects;
using WeverseShop.Config;
using WeverseShop.Manager;

namespace WeverseShop.Base
{
    /// <summary>
    /// BasePage
    /// Page Factory 를 이용하기 위해
    /// *Page 클래스들의 부모 클래스 사용
    /// </summary>
    public class BasePage : Base
    {

        public BasePage()
        {
            PageFactory.InitElements(Driver, this, new AppiumPageObjectMemberDecorator());
        }
    }
}