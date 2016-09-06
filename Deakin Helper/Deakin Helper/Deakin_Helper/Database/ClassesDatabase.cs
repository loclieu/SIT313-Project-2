using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Deakin_Helper
{
    public class ClassesDatabase
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
        public ClassesDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            // create the tables
            database.CreateTable<Classes>();
        }

        public IEnumerable<Classes> GetItems()
        {
            lock (locker)
            {
                return (from i in database.Table<Classes>() select i).ToList();
            }
        }


        // Gets Today Class
        public IEnumerable<Classes> GetTodayClass(string day)
        {
            lock (locker)
            {
                return database.Query<Classes>(string.Format("SELECT * FROM [Classes] WHERE [Day] = {0}", day));
            }
        }

        public Classes GetItem(int id)
        {
            lock (locker)
            {
                return database.Table<Classes>().FirstOrDefault(x => x.ID == id);
            }
        }

        public int SaveItem(Classes item)
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
                return database.Delete<Classes>(id);
            }
        }
    }
}
