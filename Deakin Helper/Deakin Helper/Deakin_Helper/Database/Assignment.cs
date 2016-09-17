using System;
using SQLite;


namespace Deakin_Helper
{
    public class Assignment
    {
        
            public Assignment()
            {
            }

            [PrimaryKey, AutoIncrement]
            public int ID { get; set; }
            public string UnitCode { get; set; }
            public string UnitName { get; set; }
            public string AssignmentName { get; set; }
            public string Day { get; set; }
            public string Time { get; set; }
            
        public string topLine
        {
            get
            {
                int maxLenght = 50;
                string one = UnitCode + " - " + AssignmentName;
                maxLenght = maxLenght - one.Length;
                string spacing = new string(' ', maxLenght);
                return string.Format("{0}{1}{2, 25}", one, spacing ,maxLenght);
            }
        }
        public string botLine
        {
            get
            {
                return string.Format("{0,-30}{1}", UnitName, Time);
            }
        }
    }
}
