using CLA_Generic_AUT.WebHandler;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageElement
{
    /// <summary>
    /// <button .... />
    /// </summary>
    public class BasicButtonElement: PageElementBase
    {
        public BasicButtonElement(By by, IWebHandler webHandler) : base(by, webHandler)
        {
        }

        public BasicButtonElement(By by, IWebHandler webHandler, TimeSpan timeOut) : base(by, webHandler, timeOut)
        {
        }

        public BasicButtonElement(IWebElement element) : base(element)
        {
        }

        public string GetButtonText()
        {
            var innerText = ThisElement.GetAttribute("innerText");

            if(!string.IsNullOrEmpty(innerText))
            {
                return innerText;
            }

            return ThisElement.GetAttribute("outerText");
        }

        public void ClickButton()
        {
            ThisElement.Click();
        }
    }
}
