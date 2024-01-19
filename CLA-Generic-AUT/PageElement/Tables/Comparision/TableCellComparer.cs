using OpenQA.Selenium.DevTools.V105.Network;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageElement.Tables.Comparision
{

    public class TableCellComparer : IEqualityComparer<TableCell>
    {
        public bool Equals(TableCell? x, TableCell? y)
        {
            return x.Text.ToLower() == y.Text.ToLower();
        }

        public int GetHashCode([DisallowNull] TableCell obj)
        {
            return obj.Text.GetHashCode();
        }
    }

    public class TableCellCaseSensitiveComparer : IEqualityComparer<TableCell>
    {
        public bool Equals(TableCell? x, TableCell? y)
        {
            return x.Text == y.Text;
        }

        public int GetHashCode([DisallowNull] TableCell obj)
        {
            return obj.Text.GetHashCode();
        }
    }

}
