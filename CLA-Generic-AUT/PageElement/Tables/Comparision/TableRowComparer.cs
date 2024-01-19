using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageElement.Tables.Comparision
{
    public class TableRowComparer : IEqualityComparer<ITableRow>
    {
        private IEqualityComparer<TableCell> CellComparer;

        public TableRowComparer(IEqualityComparer<TableCell> cellComparer = null)
        {
            CellComparer = cellComparer ?? new TableCellComparer();
        }

        public bool Equals(ITableRow? x, ITableRow? y)
        {
            if (x == null || y == null)  {  return false; }

            if (x.TableRowCells.Count != y.TableRowCells.Count) { return false; }

            for (int i = 0; i < x.TableRowCells.Count; i++)
            {
                if (!CellComparer.Equals(x.TableRowCells[i], y.TableRowCells[i])) { return false; }
            }

            return true;
        }

        public int GetHashCode([DisallowNull] ITableRow obj)
        {
            return obj.TableRowCells.Select(x => x.Text.GetHashCode()).Aggregate((t, hash) => HashCode.Combine(t, hash));            
        }
    }
}
