using CLA_Generic_AUT.WebHandler;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageElement.InlineStaticElements
{
    public class HeaderElement : DivElement
    {
        public HeaderElement(By by, IWebHandler webHandler) : base(by, webHandler)
        {
        }

        public HeaderElement(By by, IWebHandler webHandler, TimeSpan timeOut) : base(by, webHandler, timeOut)
        {
        }

        public HeaderElement(IWebElement element) : base(element)
        {
        }

        public int GetSize()
        {
            var size = 0;

            int.TryParse(ThisElement.TagName.Substring(1), out size);

            return size;
        }
    }
}