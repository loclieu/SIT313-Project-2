using System;
using SQLite;

namespace Deakin_Helper
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
