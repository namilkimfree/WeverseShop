using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using WeverseShop.Base;

namespace WeverseShop.Pages.My
{
    /// <summary>
    /// My Page
    /// </summary>
    public class MyPage : BasePage
    {
        [FindsByAndroidUIAutomator(ID = "continueTextView")]
        private IMobileElement<AppiumWebElement> _continueWithEmailMobileElement;

        [FindsByAndroidUIAutomator(ID = "emailTextView")]
        private IMobileElement<AppiumWebElement> _myEmailMobileElement;

        public void WaitUntilPageLoads()
        {
            Helper.WaitFor(() => _continueWithEmailMobileElement.Displayed);
        }

        /// <summary>
        /// Email로 로그인 진행 버튼 클릭
        /// </summary>
        /// <returns></returns>
        public EmailInputPage ClickContinueWithEmail()
        {
            _continueWithEmailMobileElement.Click();

            var emailInputPage = new EmailInputPage();
            return emailInputPage;
        }


        /// <summary>
        /// 로그인 완료 후 MyPage의 로그인된 E-mail ID와
        /// 처음 접속한 E-Mail이 같은지 비교
        /// </summary>
        /// <param name="email"></param>
        public void EqualsEmail(string email)
        {
            Assert.That(_myEmailMobileElement.Text == email); 
        }
    }
}