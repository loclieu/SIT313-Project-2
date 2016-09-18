using SQLite;

namespace Deakin_Helper
{
    public class Settings
    {
        public Settings()
        {
        }


        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string StudentID { get; set; }
        public string Course { get; set; }
    }
}
