using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using CommonInformation;
using DatabaseController.Models;

namespace DatabaseController.Repozitorys
{
    public static class NoteRepozitory
    {

        public static IEnumerable<Note> GetAll()
        {
            var connection = SingltoneConnection.GetInstance();
            var command = connection.CreateCommand();
            command.CommandText = "select * from NOTES";
            var reader = command.ExecuteReader();
            var result = new List<Note>();
            while(reader.Read())
            {
                result.Add(DbHelper.ParseFromDatabase(reader));
            }
            return result;  
        }
        public static Note Get(int id)
        {
            if (id < 0)
            {
                throw new Exception(LanguageDictionary.GetValue("GetNoteOperationInputError"));
            }
            var connection = SingltoneConnection.GetInstance();
            var command = connection.CreateCommand();
            command.CommandText = string.Format("select * from NOTES where {0} = @{0}", DbHelper.ResolveKey(DbField.Id));
            command.Parameters.Add(new SQLiteParameter("@"+ DbHelper.ResolveKey(DbField.Id), id));
            var reader = command.ExecuteReader();
            reader.Read();
            var res = DbHelper.ParseFromDatabase(reader);
            if (res == null)
            {
                throw new Exception(LanguageDictionary.GetFormatValue("GetNoteOperationUnknownError", id));
            }
            return res; 
        }
        public static void Insert(Note newNote)
        {
            if (newNote == null)
            {
                throw new Exception(LanguageDictionary.GetValue("AddNoteOperationInputDataError"));
            }
            var connection = SingltoneConnection.GetInstance();
            var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = 
                string.Format("insert into NOTES({0},{1},{2},{3}) values(@{0},@{1},@{2},@{3});", 
                    DbHelper.ResolveKey(DbField.Message),
                    DbHelper.ResolveKey(DbField.Date),
                    DbHelper.ResolveKey(DbField.Archived),
                    DbHelper.ResolveKey(DbField.Piority));
            command.Parameters.Add(new SQLiteParameter("@"+ DbHelper.ResolveKey(DbField.Message), newNote.Message));
            command.Parameters.Add(new SQLiteParameter("@"+ DbHelper.ResolveKey(DbField.Date), newNote.Date.ToString(Note.DataFormat, CultureInfo.InvariantCulture)));
            command.Parameters.Add(new SQLiteParameter("@"+ DbHelper.ResolveKey(DbField.Archived), newNote.IsArchived));
            command.Parameters.Add(new SQLiteParameter("@"+ DbHelper.ResolveKey(DbField.Piority), newNote.Priority));
            var result = command.ExecuteNonQuery();
            if (result == 0)
            {
                throw new Exception(LanguageDictionary.GetValue("AddNoteOperationUnknownError"));
            }
        }
        public static void Delete(int id)
        {
            if (id < 0)
            {
                throw new Exception(LanguageDictionary.GetValue("DeleteNoteOperationInputError"));
            }
            var connection = SingltoneConnection.GetInstance();
            var command = connection.CreateCommand();
            command.CommandText = string.Format("delete from NOTES where {0} = @{0}", DbHelper.ResolveKey(DbField.Id));
            command.Parameters.Add(new SQLiteParameter("@id", id));
            var rows = command.ExecuteNonQuery();
            if (rows == 0)
            {
                throw new Exception(LanguageDictionary.GetFormatValue("DeleteNoteOperationUnknownError", id));
            }
        }
        public static void Update(Note note)
        {
            if (note == null)
            {
                throw new Exception(LanguageDictionary.GetValue("UpdateNoteOperationInputDataError"));
            }
            var connection = SingltoneConnection.GetInstance();
            var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText =
                string.Format("update NOTES set {0}=@{0}, {1}=@{1}, {2}=@{2}, {3}=@{3} where {4} = @{4}",
                    DbHelper.ResolveKey(DbField.Message),
                    DbHelper.ResolveKey(DbField.Date),
                    DbHelper.ResolveKey(DbField.Archived),
                    DbHelper.ResolveKey(DbField.Piority),
                    DbHelper.ResolveKey(DbField.Id));
            command.Parameters.Add(new SQLiteParameter("@"+ DbHelper.ResolveKey(DbField.Message), note.Message));
            command.Parameters.Add(new SQLiteParameter("@"+ DbHelper.ResolveKey(DbField.Date), note.Date.ToString(Note.DataFormat, CultureInfo.InvariantCulture)));
            command.Parameters.Add(new SQLiteParameter("@"+ DbHelper.ResolveKey(DbField.Archived), note.IsArchived));
            command.Parameters.Add(new SQLiteParameter("@"+ DbHelper.ResolveKey(DbField.Piority), note.Priority));
            command.Parameters.Add(new SQLiteParameter("@"+ DbHelper.ResolveKey(DbField.Id), note.Id));
            var result = command.ExecuteNonQuery();
            if (result == 0)
            {
                throw new Exception(LanguageDictionary.GetValue("UpdateNoteOperationUnknownError"));
            }
        }
    }
}
