using CLA_Generic_AUT.WebHandler;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageElement.InlineStaticElements
{
    public class AnchorElement : DivElement
    {
        public AnchorElement(By by, IWebHandler webHandler) : base(by, webHandler)
        {
        }

        public AnchorElement(By by, IWebHandler webHandler, TimeSpan timeOut) : base(by, webHandler, timeOut)
        {
        }

        public AnchorElement(IWebElement element) : base(element)
        {
        }

        public string GetHref()
        {
            return ThisElement.GetAttribute("href");
        }
    }
}
