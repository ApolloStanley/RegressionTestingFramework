using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageElement.Tables
{
    public interface ITableRow
    {
        List<TableCell> TableRowCells { get; set; }
    }
}
