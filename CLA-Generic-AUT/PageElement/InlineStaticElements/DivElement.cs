using CLA_Generic_AUT.WebHandler;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageElement.InlineStaticElements
{
    /// <summary>
    /// <div></div>
    /// </summary>
    public class DivElement : PageElementBase
    {
        public DivElement(By by, IWebHandler webHandler) : base(by, webHandler)
        {
        }

        public DivElement(By by, IWebHandler webHandler, TimeSpan timeOut) : base(by, webHandler, timeOut)
        {
        }

        public DivElement(IWebElement element) : base(element)
        {
        }

        public string GetText()
        {
            return ThisElement.Text;
        }

        public void ClickElement()
        {
            ThisElement.Click();
        }
    }
}
