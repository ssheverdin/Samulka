using System;
using System.Collections.Generic;
using System.Text;

namespace AdminLteTheme.Models
{
    public class GridRow<T> where T : class
    {
        public GridRow()
        {

        }

        public GridRow(T rowData)
        {
            RowData = rowData;
        }

        public string CssClass => Active ? "table-active" : string.Empty;
        public bool Active { get; set; } = false;
        public T RowData { get; set; }
    }
}
