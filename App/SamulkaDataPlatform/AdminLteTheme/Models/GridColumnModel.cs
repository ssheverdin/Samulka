using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AdminLteTheme.Models
{
    public class GridColumnModel
    {
        private PropertyInfo _propertyInfo;

        public GridColumnModel(PropertyInfo propertyInfo)
        {
            _propertyInfo = propertyInfo;
            DisplayName = Name;
        }

        public PropertyInfo PropertyInfo => _propertyInfo;
        public string Name => _propertyInfo.Name;
        public Type ColumnType => _propertyInfo.PropertyType;

        public string DisplayName { get; set; }
        public bool IsVisible { get; set; } = true;

        public GridColumnModel ColumnTitle(string displayName)
        {
            DisplayName = displayName;
            return this;
        }

        public GridColumnModel Hide()
        {
            IsVisible = false;
            return this;
        }

    }
}
