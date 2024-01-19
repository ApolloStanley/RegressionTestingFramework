using CLA_Generic_AUT.WebHandler;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageElement
{
    /// <summary>
    /// <input type='text' ... /><br>
    /// </summary>
    public class InputBoxElement : PageElementBase
    {
        public InputBoxElement(By by, IWebHandler webHandler) : base(by, webHandler)
        {
        }

        public InputBoxElement(By by, IWebHandler webHandler, TimeSpan timeOut) : base(by, webHandler, timeOut)
        {
        }

        public InputBoxElement(IWebElement element) : base(element)
        {
        }

        public void ClearText()
        {
            int attempts = 0;
            while(attempts < 2) 
            {
                if(ThisElement.GetAttribute("value") != String.Empty)
                {
                    ThisElement.SendKeys(Keys.Control + 'a');
                    ThisElement.SendKeys(Keys.Backspace);
                    ThisElement.Clear();
                    break;
                }
                attempts++;
            }
        }

        public void SetText(string newText)
        {
            ThisElement.SendKeys(newText);
        }

        public string GetText()
        {
            return ThisElement.GetAttribute("value");
        }

        public void SendAListOfKeys(List<string> keys)
        {
            keys.ForEach(x => ThisElement.SendKeys(x));
        }
    }
}
