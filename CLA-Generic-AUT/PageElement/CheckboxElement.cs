using CLA_Generic_AUT.WebHandler;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageElement
{
    /// <summary>
    /// <input type="checkbox"
    /// </summary>
    public class CheckboxElement : PageElementBase
    {
        public CheckboxElement(By by, IWebHandler webHandler) : base(by, webHandler)
        { 
        }

        public CheckboxElement(By by, IWebHandler webHandler, TimeSpan timeOut) : base(by, webHandler, timeOut)
        {
        }

        public CheckboxElement(IWebElement element) : base(element)
        {
        }
        public void SelectCheckbox()
        {
            ThisElement.Click();
        }

        public string GetCheckedStatus()
        {
            return ThisElement.GetAttribute("checked");
        }
    }
}
