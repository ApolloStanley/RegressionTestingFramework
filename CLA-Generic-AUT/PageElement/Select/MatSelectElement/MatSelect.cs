using CLA_Generic_AUT.WebHandler;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CLA_Generic_AUT.PageElement.Select.MatSelect
{
    public class MatSelect : PageElementBase, ISelect<MatSelectOptions>
    {

        private bool _isOpen = false;
        private IWebHandler webHandler;
        public List<MatSelectOptions> options { get; private set; }

        public MatSelect(By by, IWebHandler webHandler) : base(by, webHandler)
        {
            this.webHandler = webHandler;
        }

        public MatSelect(By by, IWebHandler webHandler, TimeSpan timeOut) : base(by, webHandler, timeOut)
        {
            this.webHandler = webHandler;
        }

        public List<MatSelectOptions> OpenMenu()
        {
            ClickElement();
            _isOpen = true;
            Thread.Sleep(webHandler.HandlerConfig.MatSelectWaitTime);
            LoadElements();
            return options;
        }

        public void CloseMenu()
        {
            if (_isOpen)
            {
                ThisElement.SendKeys(Keys.Escape);
            }
        }

        public void ClickElement()
        {
            ThisElement.Click();
        }

        public void LoadElements()
        {
            Thread.Sleep(500);
            options = webHandler.GetElements(By.XPath(".//mat-option")).Select(x => new MatSelectOptions(x)).ToList();
        }

        public void SelectByIndex(int index)
        {

            options[index - 1].SelectOption();
        }

        public void SelectByPartialUniqueText(string partialText)
        {
            OpenMenu();
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

            CloseMenu();
        }
    }
}
