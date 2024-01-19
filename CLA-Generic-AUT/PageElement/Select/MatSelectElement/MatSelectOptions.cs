using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageElement.Select.MatSelect
{
    public class MatSelectOptions : PageElementBase
    {
        public bool OptionIsSelected { get; set; }

        public MatSelectOptions(IWebElement element) : base(element)
        {
            if (ThisElement.GetAttribute("aria-selected") != null)
            {
                OptionIsSelected = bool.Parse(ThisElement.GetAttribute("aria-selected"));
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
