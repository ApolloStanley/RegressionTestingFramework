using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageElement.Select.DefaultSelect
{
    public class SelectOptions : PageElementBase
    {
        public bool OptionIsSelected { get; set; }

        public SelectOptions(IWebElement element) : base(element)
        {
            if (ThisElement.GetAttribute("aria-selected") != null)
            {
                OptionIsSelected = bool.Parse(ThisElement.GetAttribute("selected"));
            }
            else
            { OptionIsSelected = false; }

        }

        public void SelectOption()
        {
            if (OptionIsSelected) { return; }

            OptionIsSelected = true;
            ThisElement.Click();
        }

        public void DeselecttOption()
        {
            if (!OptionIsSelected) { return; }

            OptionIsSelected = false;
            ThisElement.Click();
        }
    }
}
