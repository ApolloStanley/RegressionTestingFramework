using CLA_Generic_AUT.WebHandler;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageElement.Tables
{
    public class TableRow: PageElementBase, ITableRow
    {
        public List<TableCell> TableRowCells { get; set; }
        public TableRow(IWebElement element) : base(element)
        {
            LoadTableCells();
        }

        private void LoadTableCells()
        {
            TableRowCells = ThisElement.FindElements(By.XPath(".//td"))?.Select(x => new TableCell(x))?.ToList();
        }
    }
}
