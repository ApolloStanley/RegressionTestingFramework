using CLA_Generic_AUT.WebHandler;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageElement
{
    public abstract class PageElementBase: IPageElement
    {
        protected IWebElement ThisElement;
        public bool IsDisplayed => ThisElement.Displayed; 
        public bool IsEnabled  => ThisElement.Enabled; 
        public bool IsSelected => ThisElement.Selected;
        public string TagName => ThisElement.TagName;
        public string Text => ThisElement.Text;

        public PageElementBase(By by, IWebHandler webHandler)
        {
            ThisElement = webHandler.GetElement(by);
        }

        public PageElementBase(By by, IWebHandler webHandler, TimeSpan timeOut)
        {
            ThisElement = webHandler.GetElement(by, timeOut);
        }

        /// <summary>
        /// This is a constructor when a parent element is loading child elements; table rows loads table cells...
        /// </summary>
        public PageElementBase(IWebElement element)
        {
            ThisElement = element;
        }

        public void Click() => ThisElement.Click();

        public string AttributeValue(string attribute) => ThisElement.GetAttribute(attribute);
    }
}
