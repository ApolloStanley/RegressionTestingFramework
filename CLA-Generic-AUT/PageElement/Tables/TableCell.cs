using AngleSharp.Dom;
using CLA_Generic_AUT.WebHandler;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageElement.Tables
{
    public class TableCell : PageElementBase
    {
        public TableCell(IWebElement element) : base(element)
        {
        }

        public IWebElement loadSingleCellElement(By by)
        {
            return ThisElement.FindElement(by);
        }

    }
}
