using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using WeverseShop.Base;
using WeverseShop.Pages.My;

namespace WeverseShop.Pages
{
    public class PasswordInputPage : BasePage
    {
        [FindsByAndroidUIAutomator(ID = "passwordEditText")]
        private IMobileElement<AppiumWebElement> _passwordInputMobileElement;

        [FindsByAndroidUIAutomator(ID = "nextTextView")]
        private IMobileElement<AppiumWebElement> _nextMobileElement;


        public void WaitUntilPageLoads()
        {
            Helper.WaitFor(() => _nextMobileElement.Displayed);
        }

        public void InputPassword(string password)
        {
            _passwordInputMobileElement.SendKeys(password);
        }

        public MyPage ClickLogin()
        {
            _nextMobileElement.Click();

            var myPage = new MyPage();

            return myPage;
        }

    }
}