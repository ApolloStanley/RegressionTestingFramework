using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageElement.Tables.Comparision
{
    public class TableBodyComparer
    {
        public bool ContainsSameRows(TableBody tableOne, TableBody tableTwo)
        {
            var tableOneUniqueRows = tableOne.TableRows.Except(tableTwo.TableRows, new TableRowComparer());
            var tableTwoUniqueRows = tableTwo.TableRows.Except(tableOne.TableRows, new TableRowComparer());

            return !tableOneUniqueRows.Any() && !tableTwoUniqueRows.Any();
        }

        public bool ContainsSameRowsInOrder(TableBody tableOne, TableBody tableTwo)
        {
            return tableOne.TableRows.SequenceEqual(tableTwo.TableRows, new TableRowComparer());
        }

        public List<ITableRow> FindRowsDifferentInTableOne(TableBody tableOne, TableBody tableTwo)
        {
            return tableOne.TableRows.Except(tableTwo.TableRows, new TableRowComparer()).ToList();
        }

        public List<ITableRow> FindRowsDifferentInTableTwo(TableBody tableOne, TableBody tableTwo)
        {
            return tableTwo.TableRows.Except(tableOne.TableRows, new TableRowComparer()).ToList();
        }
    }
}
