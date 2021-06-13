using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using WeverseShop.Base;
using WeverseShop.Pages;
using WeverseShop.Pages.My;

namespace WeverseShop.Steps
{
    [Binding]
    public sealed class LoginTest : BaseStep
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public LoginTest(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"my tab click in main activity")]
        public void GivenMyTabClickInMainActivity()
        {
            var homePage = new HomePage();

            CurrentBasePage = homePage.ClickMyPageTab();
        }

        [When(@"with email click")]
        public void WhenWithEmailClick()
        {
            var myPage = CurrentBasePage as MyPage;

            myPage.WaitUntilPageLoads();

            CurrentBasePage = myPage.ClickContinueWithEmail();
        }

        [When(@"input the email '(.*)'")]
        public void WhenInputTheEmail(string email)
        {
            var emailInputPage = CurrentBasePage as EmailInputPage;

            emailInputPage.WaitUntilPageLoads();

            emailInputPage.InputEmail(email);
        }

        [When(@"next button click")]
        public void WhenNextButtonClick()
        {
            var emailInputPage = CurrentBasePage as EmailInputPage;
            CurrentBasePage = emailInputPage.ClickContinueWithEmail();
        }

        [When(@"input the password '(.*)'")]
        public void WhenInputThePassword(string password)
        {
            var passwordInputPage = CurrentBasePage as PasswordInputPage;

            passwordInputPage.WaitUntilPageLoads();

            passwordInputPage.InputPassword(password);

        }

        [When(@"login click")]
        public void WhenLoginClick()
        {
            var passwordInputPage = CurrentBasePage as PasswordInputPage;

            CurrentBasePage = passwordInputPage.ClickLogin();
        }

        [Then(@"check login id '(.*)'")]
        public void ThenCheckLoginId(string assertEmail)
        {
            var myPage = CurrentBasePage as MyPage;

            myPage.EqualsEmail(assertEmail);
        }

    }
}
