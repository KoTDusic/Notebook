using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using DatabaseController.Models;

namespace DatabaseController
{
    internal enum DbField
    {
        Id,
        Message,
        Date,
        Archived,
        Piority

    }
    internal static class DbHelper
    {
        private static Dictionary<DbField, string> dbFields = new Dictionary<DbField, string>();
        static DbHelper()
        {
            dbFields.Add(DbField.Id, "id");
            dbFields.Add(DbField.Message, "note");
            dbFields.Add(DbField.Date, "date");
            dbFields.Add(DbField.Archived, "isArhived");
            dbFields.Add(DbField.Piority, "priority");
        }

        public static string ResolveKey(DbField key)
        {
            string result;
            dbFields.TryGetValue(key, out result);
            if (result == null)
            {
                result = "ERROR_DB_FIELDNAME";
            }
            return result;
        }
        public static Note ParseFromDatabase(IDataRecord reader)
        {
            return new Note
            {
                Id = Convert.ToInt32(reader["id"]),
                Priority = (NotePriority)Enum.ToObject(typeof(NotePriority), reader["priority"]),
                //http://blog.stevex.net/string-formatting-in-csharp/
                Date = DateTime.ParseExact(reader["date"].ToString(), Note.DataFormat, CultureInfo.InvariantCulture),
                Message = reader["note"].ToString(),
                IsArchived = Convert.ToBoolean(reader["isArhived"].ToString())
            };
        }
    }
}
