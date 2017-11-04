using System.Data.SQLite;

namespace DatabaseController
{
    public static class SingltoneConnection
    {
        private static SQLiteConnection _connection;
        private static readonly object SyncObject=new object();

        public static SQLiteConnection GetInstance()
        {
            lock (SyncObject)
            {
                if (_connection != null)
                {
                    return _connection;
                }
                _connection = new SQLiteConnection("Data Source=notes.db; Version=3;");
                _connection.Open();
                return _connection;
            }
        }
    }
}
