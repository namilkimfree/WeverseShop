using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using WeverseShop.Base;

namespace WeverseShop.Pages.My
{

    /// <summary>
    /// Email Input Page
    /// </summary>
    public class EmailInputPage : BasePage
    {
        [FindsByAndroidUIAutomator(ID = "emailEditText")]
        private IMobileElement<AppiumWebElement> _emailInputMobileElement;

        [FindsByAndroidUIAutomator(ID = "nextTextView")]
        private IMobileElement<AppiumWebElement> _nextMobileElement;


        public void WaitUntilPageLoads()
        {
            Helper.WaitFor(() => _nextMobileElement.Displayed);
        }


        /// <summary>
        /// Input email
        /// </summary>
        /// <param name="email"></param>
        public void InputEmail(string email)
        {
            _emailInputMobileElement.SendKeys(email);
        }

        /// <summary>
        /// 계속 진행 버튼 클릭
        /// </summary>
        /// <returns></returns>
        public PasswordInputPage ClickContinueWithEmail()
        {
            _nextMobileElement.Click();
            var passwordInputPage = new PasswordInputPage();

            return passwordInputPage;
        }

    }
}