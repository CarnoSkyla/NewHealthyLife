using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyLifeApp.Models
{
    public class Schedule
    {
        [PrimaryKey, AutoIncrement]
        public int TaskID { get; set; }
        public string Task { get; set; }
        public string TaskDetails { get; set; }
        public string TaskIcon { get; set; }
        public string Time { get; set; }
    }
}
