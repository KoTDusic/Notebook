using System.Globalization;
using System.Linq;
using DatabaseController.Models;
using SQLite;

namespace DatabaseController
{
    public static class SingltoneConnection
    {
        private static SQLiteConnection _connection;
        private static readonly object SyncObject=new object();
        public const string DatabaseFilename = "notes.db";

        private const string NotesCreateScript = "CREATE TABLE NOTES ( " +
                                                 "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                                 "note STRING, " +
                                                 "date STRING, " +
                                                 "isArhived BOOLEAN, " +
                                                 "priority INTEGER);";

        public static SQLiteConnection GetInstance()
        {
            lock (SyncObject)
            {
                if (_connection != null)
                {
                    return _connection;
                }
                _connection = new SQLiteConnection(DatabaseFilename, SQLiteOpenFlags.ReadWrite|SQLiteOpenFlags.Create);
                var tableName = _connection.Table<Note>().Table.TableName;
                var table = _connection.GetTableInfo(tableName);
                if (table.Count == 0)
                {
                    _connection.Execute(NotesCreateScript);
                }
                return _connection;
            }
        }
    }
}
