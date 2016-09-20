﻿using System;
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
            public DateTime DueDate { get; set; }
            public TimeSpan DueTime { get; set; }
            
       
    }
}
