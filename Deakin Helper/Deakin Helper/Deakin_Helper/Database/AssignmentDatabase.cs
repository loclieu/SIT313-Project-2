using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Deakin_Helper
{
    public class AssignmentDatabase
    {
        static object locker = new object();

        SQLiteConnection database;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
        /// if the database doesn't exist, it will create the database and all the tables.
        /// </summary>
        /// <param name='path'>
        /// Path.
        /// </param>
        public AssignmentDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            // create the tables
            database.CreateTable<Assignment>();
        }

        public IEnumerable<Assignment> GetItems()
        {
            lock (locker)
            {
                return (from i in database.Table<Assignment>() select i).ToList();
            }
        }

        public IEnumerable<Assignment> GetTodayAssignment(DateTime today, DateTime dueSoon)
        {
            lock (locker)
            {
                return database.Query<Assignment>("SELECT * FROM [Assignment] WHERE [DueDate] BETWEEN ? AND ?", today, dueSoon);
            }
        }



        public Assignment GetItem(int id)
        {
            lock (locker)
            {
                return database.Table<Assignment>().FirstOrDefault(x => x.ID == id);
            }
        }

        public int SaveItem(Assignment item)
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    database.Update(item);
                    return item.ID;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<Assignment>(id);
            }
        }
    }
}
