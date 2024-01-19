using CLA_Generic_AUT.WebHandler;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageElement.Tables
{
    public class TableBody
    {
        public List<TableRow> TableRows { get; set; } = new List<TableRow>();
        protected IWebHandler handler;
        private IWebElement ParentObject;

        public TableBody(IWebElement parentObject)
        {
            ParentObject = parentObject;    
            LoadTableRowCells();
        }

        private void LoadTableRowCells()
        {
            // for each tr convert to tableRow object 
            TableRows = ParentObject.FindElements(By.XPath(".//tbody//tr"))?.Select(x => new TableRow(x))?.ToList();
            if (TableRows !=null && TableRows.Count > 0 && TableRows[0].TableRowCells.Count == 0)
            {
                TableRows.RemoveAt(0);
            }
        }
    }
}
