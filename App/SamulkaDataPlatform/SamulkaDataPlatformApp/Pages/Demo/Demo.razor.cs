using AdminLteTheme.Models;
using SamulkaDataPlatformApp.Data;
using SamulkaDataPlatformApp.Service;
using System.Collections.Generic;

namespace SamulkaDataPlatformApp.Pages.Demo
{
    public partial class Demo : StatePageComponent
    {
        public override string PageTitle => "Demo";

        public List<ToDoTask> Data = new List<ToDoTask>();

        protected override void OnInitialized()
        {
            Data = DummyData.GetTaskData();
            base.OnInitialized();
        }

        //private void GetColumns(GridColumnsSettings<ToDoTask> settings)
        //{
        //    settings
        //        .Column(col => col.Id,cfg => cfg.Hide())
        //        .Column(col => col.Name,cfg => cfg.ColumnTitle("Title"))
        //        .Column(col => col.DueDate,cfg => cfg.ColumnTitle("Due On"))
        //        .Column(col => col.TaskNumber,cfg => cfg.ColumnTitle("#"));
            
        //}
    }
}
