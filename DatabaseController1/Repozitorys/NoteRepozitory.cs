﻿using System;
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
            List<Note> result = new List<Note>();
            while(reader.Read())
            {
                result.Add(new Note
                {
                    Id = Convert.ToInt32(reader["id"]),
                    //http://blog.stevex.net/string-formatting-in-csharp/
                    
                    Date = DateTime.ParseExact(reader["date"].ToString(),Note.DataFormat, CultureInfo.InvariantCulture),
                    Message = reader["note"].ToString(),
                    IsArchived = Convert.ToBoolean(reader["isArhived"].ToString())
                });
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
            command.CommandText = "select * from NOTES where id = @id";
            command.Parameters.Add(new SQLiteParameter("@id", id));
            var reader = command.ExecuteReader();
            reader.Read();
            Note res = new Note
            {
                Id = Convert.ToInt32(reader["id"]),
                Date = DateTime.ParseExact(reader["date"].ToString(), Note.DataFormat, CultureInfo.InvariantCulture),
                Message = reader["note"].ToString(),
                IsArchived = Convert.ToBoolean(reader["isArhived"].ToString())
            };
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
            command.CommandText = "insert into NOTES(note,date,isArhived) values(@note,@date,@archived);";
            command.Parameters.Add(new SQLiteParameter("@note",newNote.Message));
            command.Parameters.Add(new SQLiteParameter("@date", newNote.Date.ToString(Note.DataFormat, CultureInfo.InvariantCulture)));
            command.Parameters.Add(new SQLiteParameter("@archived", newNote.IsArchived));
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
            command.CommandText = "delete from NOTES where id = @id";
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
            command.CommandText = "update NOTES set note=@note, date=@date, isArhived=@archived where id = @id";
            command.Parameters.Add(new SQLiteParameter("@note", note.Message));
            command.Parameters.Add(new SQLiteParameter("@date", note.Date.ToString(Note.DataFormat, CultureInfo.InvariantCulture)));
            command.Parameters.Add(new SQLiteParameter("@archived", note.IsArchived));
            command.Parameters.Add(new SQLiteParameter("@id", note.Id));
            var result = command.ExecuteNonQuery();
            if (result == 0)
            {
                throw new Exception(LanguageDictionary.GetValue("UpdateNoteOperationUnknownError"));
            }
        }
    }
}
