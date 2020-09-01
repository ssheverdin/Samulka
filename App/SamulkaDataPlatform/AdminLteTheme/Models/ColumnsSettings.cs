using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace AdminLteTheme.Models
{
    public class GridColumnsSettings<T>
    {
    //    private Dictionary<string, GridColumn> _columns = new Dictionary<string, GridColumn>();

    //    public GridColumnsSettings()
    //    {
            
    //    }

    //    public GridColumnsSettings<T> Column(Expression<Func<T,object>> property, Expression<Action<GridColumn>> settings)
    //    {
    //        string propertyName = "";
    //        if(property.Body is UnaryExpression)
    //        {
    //            var propertyOperand = ((UnaryExpression)property.Body).Operand;
    //            propertyName = ((MemberExpression)propertyOperand).Member.Name;
                
    //        }
    //        if(property.Body is MemberExpression)
    //        {
    //            propertyName = ((MemberExpression)property.Body).Member.Name;
    //        }

    //        var setSettings = settings.Compile();
    //        setSettings(_columns[propertyName]);

    //        return this;
    //    }

    //    public List<GridColumn> Columns => _columns.Values.Where(i => i.IsVisible).ToList();
    }
}
