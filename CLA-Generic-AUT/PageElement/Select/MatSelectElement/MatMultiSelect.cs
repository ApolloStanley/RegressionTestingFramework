using CLA_Generic_AUT.WebHandler;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageElement.Select.MatSelect.MatMultiSelect
{
    public class MatMultiSelect : MatSelect
    {
        public MatMultiSelect(By by, IWebHandler webHandler) : base(by, webHandler)
        {
        }

        public MatMultiSelect(By by, IWebHandler webHandler, TimeSpan timeOut) : base(by, webHandler, timeOut)
        {
        }

        public void SelectMultiple(List<string> optionsToSelect)
        {
            optionsToSelect.ForEach(option => SelectByPartialUniqueText(option));
        }

        public void SelectMultiple(List<int> optionsToSelect)
        {
            optionsToSelect.ForEach(option => SelectByIndex(option));
        }

        public void SelectAll()
        {
            options.ForEach(x => x.SelectOption());
        }

        public void DeselectAll()
        {
            options.ForEach(x => x.DeselecttOption());
        }

        public void Submit()
        {
            ThisElement.SendKeys(Keys.Escape);
        }
    }
}
