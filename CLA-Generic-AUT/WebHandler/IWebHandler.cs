using CLA_Generic_AUT.WebHandler.Config;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace CLA_Generic_AUT.WebHandler
{
    public interface IWebHandler: IDisposable
    {
        WebHandlerConfig HandlerConfig { get; set; }

        void Navigate(string URL);

        ReadOnlyCollection<IWebElement> GetElements(By by);

        IWebElement GetElement(By by);

        IWebElement GetElement(By by, TimeSpan timeOut);

        void SwitchToOtherTab();

        void SwitchToAnyOtherTab();

        void ScrollTabToTopOfPage();

        void ScrollTabToBottomOfPage();

        string GetUrl();

        string GetAlertText();

        void AcceptAlert();

        void DismissAlert();

        void SentTextToAlert(string text);
    }
}