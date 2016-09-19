using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Deakin_Helper
{
    public class SettingsDatabase
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
        public SettingsDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            
            // create the tables
            database.CreateTable<Settings>();
        }

        public IEnumerable<Settings> GetItems()
        {
            lock (locker)
            {
                return (from i in database.Table<Settings>() select i).ToList();
            }
        }

        // Get entries
        public IEnumerable<Settings> GetCount()
        {
            lock (locker)
            {
                return database.Query<Settings>("SELECT count(*) FROM [Settings]");
            }
        }

        // Gets Today Class
        //public IEnumerable<Settings> GetTodayClass(string day)
        //{
        //    lock (locker)
        //    {
        //        return database.Query<Settings>(string.Format("SELECT * FROM [Classes] WHERE [Day] = {0}", day));
        //    }
        //}

        public Settings GetItem(int id)
        {
            lock (locker)
            {
                return database.Table<Settings>().FirstOrDefault(x => x.ID == id);
            }
        }

        public int SaveItem(Settings item)
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
                return database.Delete<Settings>(id);
            }
        }
    }
}
