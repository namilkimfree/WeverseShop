using System;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Support.UI;

namespace WeverseShop.Manager
{
    public class AppiumHelper
    {
        private readonly AppiumManager _appiumManager;

        public AppiumHelper(AppiumManager appiumManager)
        {
            _appiumManager = appiumManager;
        }


        #region Wait

        public void WaitForElement(AppiumWebElement appiumWebElement)
        {
            var fluentWait = new DefaultWait<AppiumDriver<AppiumWebElement>>(_appiumManager.AppiumDriver);
            fluentWait.Timeout = TimeSpan.FromMilliseconds(_appiumManager.Config.TimeoutMilliseconds);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Until(x => appiumWebElement.Displayed);
        }

        public AppiumWebElement WaitForElement(string xPath)
        {
            var fluentWait = new DefaultWait<AppiumDriver<AppiumWebElement>>(_appiumManager.AppiumDriver);
            fluentWait.Timeout = TimeSpan.FromMilliseconds(_appiumManager.Config.TimeoutMilliseconds);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            var element = fluentWait.Until(x => _appiumManager.AppiumDriver.FindElementByXPath(xPath));

            return element;
        }


        /// <summary>
        /// timeout 발생하기 전까지
        /// 특정 action을 진행
        /// 특정 action 진행시 완료
        /// 특정 action을 timeout 전까지 못할 경우 throw
        /// </summary>
        /// <param name="condition"></param>
        public void WaitFor(Func<bool> condition)
        {
            var wait = new WebDriverWait(_appiumManager.AppiumDriver, TimeSpan.FromMilliseconds(_appiumManager.Config.TimeoutMilliseconds));
            wait.Timeout = TimeSpan.FromMilliseconds(_appiumManager.Config.TimeoutMilliseconds);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            try
            {
                wait.Until(drv => EvaluateConditionWithoutThrowing(condition));
            }
            catch (WebDriverTimeoutException)
            {
                // Force same exception
                condition();
            }
        }

        /// <summary>
        /// timeout 발생하기 전까지
        /// 특정 action을 진행
        /// 특정 action 진행시 완료
        /// 특정 action을 timeout 전까지 못할 경우 throw
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public AppiumWebElement WaitFor(Func<AppiumWebElement> condition)
        {
            var wait = new WebDriverWait(_appiumManager.AppiumDriver, TimeSpan.FromMilliseconds(_appiumManager.Config.TimeoutMilliseconds));
            wait.Timeout = TimeSpan.FromMilliseconds(_appiumManager.Config.TimeoutMilliseconds);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            try
            {
                return wait.Until(drv => EvaluateConditionWithoutThrowing(condition));
            }
            catch (WebDriverTimeoutException)
            {
                // Force same exception
                return condition();
            }
        }

        #endregion

        private AppiumWebElement EvaluateConditionWithoutThrowing(Func<AppiumWebElement> condition)
        {
            try
            {
                return condition();
            }
            catch
            {
                return null;
            }
        }

        private bool EvaluateConditionWithoutThrowing(Func<bool> condition)
        {
            try
            {
                return condition();
            }
            catch
            {
                return false;
            }
        }

        private IMobileElement<AppiumWebElement> EvaluateConditionWithoutThrowing(Func<IMobileElement<AppiumWebElement>> condition)
        {
            try
            {
                return condition();
            }
            catch
            {
                return null;
            }
        }



        /// <summary>
        /// Scroll하면서
        /// 찾고자 하는 Element 찾는 함수
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="scrollElement"></param>
        /// <returns></returns>
        internal IMobileElement<AppiumWebElement> ScrollDownUntilCondition(Func<IMobileElement<AppiumWebElement>> condition, IMobileElement<AppiumWebElement> scrollElement)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            IMobileElement<AppiumWebElement> ele = null;

            while ((ele = EvaluateConditionWithoutThrowing(condition)) == null)
            {
                ScrollDown(scrollElement: scrollElement);

                if (stopwatch.Elapsed.Seconds > 30)
                {
                    try
                    {
                        condition();

                        throw new WebDriverException("Scrolling down timed out as condition was not met");
                    }
                    catch
                    {
                        throw;
                    }
                }
            }

            return ele;
        }

        /// <summary>
        /// 스크롤 하면서
        /// 조건에 만족하면 특정 action 진행
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="scrollElement"></param>
        internal void ScrollDownUntilCondition(Func<bool> condition, IMobileElement<AppiumWebElement> scrollElement)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while (!EvaluateConditionWithoutThrowing(condition))
            {
                ScrollDown(scrollElement: scrollElement);

                if (stopwatch.Elapsed.Seconds > 30)
                {
                    try
                    {
                        condition();

                        throw new WebDriverException("Scrolling down timed out as condition was not met");
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// 스크롤 하면서
        /// 조건에 만족하면 특정 action 진행
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="scrollElement"></param>
        internal void ScrollHorizonUntilCondition(Func<bool> condition, IMobileElement<AppiumWebElement> scrollElement)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while (!EvaluateConditionWithoutThrowing(condition))
            {
                ScrollHorizon(scrollElement: scrollElement);

                if (stopwatch.Elapsed.Seconds > 120)
                {
                    try
                    {
                        condition();

                        throw new WebDriverException("Scrolling down timed out as condition was not met");
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// X축 스크롤
        /// 스크롤 view를 기반으로
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="scrollElement"></param>

        private void ScrollHorizon(int? offset = null, IMobileElement<AppiumWebElement> scrollElement = null)
        {
            var startx = scrollElement.Size.Width / 2;
            var starty = scrollElement.Location.Y;
            offset ??= ((scrollElement.Size.Width / 2) - 10) > scrollElement.Location.X ? ((scrollElement.Size.Width / 2) - 10) : scrollElement.Location.X;
            
            var endx = startx - offset.Value;

            new TouchAction(_appiumManager.AppiumDriver).Press(startx, starty).Wait(ms: 1000).MoveTo(endx, starty).Release().Perform();
        }

        /// <summary>
        /// Y축 Scroll
        /// 스크롤 view를 기반으로
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="scrollElement"></param>
        private void ScrollDown(int? offset = null, IMobileElement<AppiumWebElement> scrollElement = null)
        {
            var startx = scrollElement.Size.Width / 2;
            var starty = scrollElement.Size.Height / 2;
            offset ??= ((scrollElement.Size.Height / 2) - 10) > scrollElement.Location.Y ? ((scrollElement.Size.Height / 2) - 10) : scrollElement.Location.Y; 
            var endy = starty - offset.Value;

            new TouchAction(_appiumManager.AppiumDriver).Press(startx, starty).Wait(ms: 1000).MoveTo(startx, endy).Release().Perform();
        }
     
    }
}