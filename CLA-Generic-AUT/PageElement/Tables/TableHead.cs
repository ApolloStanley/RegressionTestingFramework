using CLA_Generic_AUT.WebHandler;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageElement.Tables
{
    public class TableHead: ITableRow
    {
        public TableCell this[int row]
        {
            get { return TableRowCells[row - 1]; }
        }

        public List<TableCell> TableRowCells { get; set; }
        private IWebElement ParentObject;

        public TableHead(IWebElement parentObject) 
        {
            ParentObject = parentObject;
            LoadTableRowCells();
        }

        private void LoadTableRowCells()
        {
            TableRowCells = ParentObject.FindElements(By.XPath(".//th")).Select(x => new TableCell(x)).ToList();
        }
    }
}
