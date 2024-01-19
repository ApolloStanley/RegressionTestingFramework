using CLA_Generic_AUT.WebHandler;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageElement.Tables
{
    public class TableCollectionObject : PageElementBase
    {

        // Define the indexer to allow client code to use [] notation.
        public TableCell this[int row, int col]
        {
            get { return TableBody.TableRows[row - 1].TableRowCells[col - 1]; } 
        }
        public TableCell this[int row, String HeaderTitle]
        {
            get { 
                var j = GetOrdinal(HeaderTitle);
                return TableBody.TableRows[row - 1].TableRowCells[j]; 
            }
        }

        public TableHead TableHeader { get; set; }

        public TableBody TableBody { get; set; }

        public TableCollectionObject(By by, IWebHandler webHandler) : base(by, webHandler)
        {
            LoadTableHeader();
            LoadTableBody();
        }

        public TableCollectionObject(By by, IWebHandler webHandler, TimeSpan timeOut) : base(by, webHandler, timeOut)
        {
            LoadTableHeader();
            LoadTableBody();
        }

        private void LoadTableHeader()
        {
            TableHeader = new TableHead(ThisElement);
        }

        private void LoadTableBody()
        {
            TableBody = new TableBody(ThisElement);
        }

        public int GetOrdinal(string headerValue)
        {
            return TableHeader.TableRowCells.FindIndex(x => x.Text.Equals(headerValue)); // returns -1 when not found
        }
    }
}
