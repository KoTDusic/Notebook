using System.Data.SQLite;

namespace Ежедневник
{
    public class SingltoneConnection
    {
        private static SQLiteConnection connection;
        private SingltoneConnection(){}
        public static SQLiteConnection GetInstance()
        {
            if (connection == null)
            {
                connection = new SQLiteConnection("Data Source=notes.db; Version=3;");
                connection.Open();
            }
            return connection;
        }
    }
}
