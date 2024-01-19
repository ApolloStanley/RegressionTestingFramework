using CLA_Generic_AUT.PageElement.Select.MatSelect;
using CLA_Generic_AUT.WebHandler;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageElement.Select.DefaultSelect
{
    public class Select : PageElementBase, ISelect<SelectOptions>
    {

        private IWebHandler webHandler;
        public List<SelectOptions> options { get; private set; }

        public Select(By by, IWebHandler webHandler) : base(by, webHandler)
        {
            this.webHandler = webHandler;
        }

        public Select(By by, IWebHandler webHandler, TimeSpan timeOut) : base(by, webHandler, timeOut)
        {
            this.webHandler = webHandler;
        }

        public List<SelectOptions> OpenMenu()
        {
            ClickElement();
            Thread.Sleep(webHandler.HandlerConfig.MatSelectWaitTime);
            LoadElements();
            return options;
        }

        public void ClickElement()
        {
            ThisElement.Click();
        }

        public void LoadElements()
        {
            options = webHandler.GetElements(By.XPath(".//option")).Select(x => new SelectOptions(x)).ToList();
        }

        public void SelectByIndex(int index)
        {

            options[index - 1].SelectOption();
        }

        public void SelectByPartialUniqueText(string partialText)
        {
            var results = options.Where(x => x.Text.ToLower().Contains(partialText.ToLower())).ToList();

            if (results.Count == 0)
            {
                throw new Exception("No options found");

            }

            if (results.Count > 1)
            {
                throw new Exception("None unique text provided");
            }

            results[0].SelectOption();
        }
    }
}
