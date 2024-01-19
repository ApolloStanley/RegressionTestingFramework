using CLA_Generic_AUT.WebHandler.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;

namespace CLA_Generic_AUT.WebHandler.SeleniumHandler
{
    public abstract class SeleniumBase : IWebHandler
    {
        protected IWebDriver _driver;

        public WebHandlerConfig HandlerConfig { get; set; }

        protected void SetBaseConfig(WebHandlerConfig webHandlerConfig)
        {
            if (webHandlerConfig.ResolutionX != null && webHandlerConfig.ResolutionY != null)
            {
                _driver.Manage().Window.Size = new Size(webHandlerConfig.ResolutionX.Value, webHandlerConfig.ResolutionY.Value);
            }

            HandlerConfig = webHandlerConfig;
        }

        public void Navigate(string URL)
        {
            _driver.Navigate().GoToUrl(URL);
        }

        public ReadOnlyCollection<IWebElement> GetElements(By by)
        {
            return _driver.FindElements(by);
        }

        public IWebElement GetElement(By by)
        {
            return _driver.FindElement(by);
        }

        public IWebElement GetElement(By by, TimeSpan timeOut)
        {
            return new WebDriverWait(_driver, timeOut).Until(driver => driver.FindElement(by));
        }


        public void Dispose()
        {
            if (_driver != null) { _driver.Dispose(); }
        }

        public void SwitchToOtherTab()
        {
            if (_driver.WindowHandles.Count < 2)
            {
                throw new InvalidOperationException("Less than 2 tabs, could not switch");
            }
            var otherTab = _driver.WindowHandles.FirstOrDefault(x => x != _driver.CurrentWindowHandle);
            _driver.SwitchTo().Window(otherTab);
        }

        public void SwitchToAnyOtherTab()
        {
            var tabs = new ArrayList(_driver.WindowHandles);

            foreach (string tab in tabs)
            {
                _driver.SwitchTo().Window(tab);
            }
        }


        public void ScrollTabToTopOfPage()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)_driver;
            jse.ExecuteScript("window.scrollTo(0, 0)");
        }

        public void ScrollTabToBottomOfPage()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)_driver;
            jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }

        public string GetUrl()
        {
            return _driver.Url;
        }

        public string GetAlertText()
        {
            return _driver.SwitchTo().Alert().Text;
        }

        public void AcceptAlert()
        {
            _driver.SwitchTo().Alert().Accept();
        }

        public void DismissAlert()
        {
            _driver.SwitchTo().Alert().Dismiss();
        }

        public void SentTextToAlert(string text)
        {
            _driver.SwitchTo().Alert().SendKeys(text);
        }
    }
}
