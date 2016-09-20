using System;
using SQLite;

namespace Deakin_Helper
{
    public class Classes
    {
        public Classes()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public string RoomNumber { get; set; }
        public TimeSpan ClassTime { get; set; }
        public string ClassType { get; set; }
        public DateTime ClassDate { get; set; }
    }
}
