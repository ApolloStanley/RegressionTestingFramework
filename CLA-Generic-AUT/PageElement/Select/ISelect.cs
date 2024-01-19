using CLA_Generic_AUT.PageElement.Select.DefaultSelect;
using CLA_Generic_AUT.PageElement.Select.MatSelect;
using CLA_Generic_AUT.PageObjects;
using CLA_Generic_AUT.WebHandler;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageElement.Select
{
    public interface ISelect<T>
    {
        List<T> OpenMenu();

        void ClickElement();

        void LoadElements();

        void SelectByIndex(int index);

        void SelectByPartialUniqueText(string matchingPartialText);
    }
}
