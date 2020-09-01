using AdminLteTheme.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminLteTheme.Models
{
    public abstract class GridBase : ComponentBase
    {
        protected Dictionary<string, GridColumn> _columns = new Dictionary<string, GridColumn>();

        public void AddColumn(GridColumn gridColumn)
        {
            if (_columns.ContainsKey(gridColumn.Field))
            {
                _columns[gridColumn.Field] = gridColumn;
            }
            else
            {
                _columns.Add(gridColumn.Field, gridColumn);
            }
            StateHasChanged();
        }

    }
}
