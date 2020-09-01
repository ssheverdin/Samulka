using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamulkaDataPlatformApp.Data
{
    public static class DummyData
    {
        public static List<ToDoTask> GetTaskData()
        {
            int recordsCount = 54;
            var rand = new Random();
            var dateNow = DateTime.Now;
            List<ToDoTask> result = new List<ToDoTask>();
            for(int i = 0; i <= recordsCount; i++)
            {
                int month = rand.Next(12)+1;
                int day = rand.Next(24) + 1;
                result.Add(new ToDoTask()
                {
                    Id = i + 1,
                    TaskNumber = rand.Next(1001),
                    Name = Titles()[rand.Next(4)],
                    DueDate = new DateTime(2020, month, day),
                    Completed = rand.NextDouble(),
                    Done = dateNow > new DateTime(2020, month, day),
                    Status = Statuses()[rand.Next(3)],
                    Comments = "Bacon ipsum dolor sit amet salami venison chicken flank fatback doner. Bacon ipsum dolor sit amet salami venison chicken flank fatback doner. Bacon ipsum dolor sit amet salami venison chicken flank fatback doner."

                });
            }
            return result;
        }

        private static string[] Statuses()
        {
            string[] ar = { "Pending", "Approved", "Denied" };
            return ar;
        }

        private static string[] Titles()
        {
            string[] ar = { "Update software", "Clean database", "Cron job running", "Fix and squish bugs" };
            return ar;
        }
    }


    public class ToDoTask
    {
        public int Id { get; set; }
        public int TaskNumber { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public double Completed { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public bool Done { get; set; }
    }
}
