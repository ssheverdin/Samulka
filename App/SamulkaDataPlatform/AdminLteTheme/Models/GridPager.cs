using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdminLteTheme.Models
{
    public class GridPager 
    {
        private IEnumerable<object> _data;

        public int DataCount => _data.Count();

        public int PageSize { get; set; } = 10;

        public int PageCount
        {
            get
            {
                var totalRecordsCount = DataCount;
                if (totalRecordsCount <= PageSize)
                {
                    return 1;
                }
                if (totalRecordsCount % PageSize >= 1)
                {
                    return DataCount / PageSize + 1;
                }
                return totalRecordsCount / PageSize;
            }
        }

        public int CurrentPage { get; set; } = 1;



        public GridPager(IEnumerable<object> data)
        {
            _data = data;
        }
    }
}
