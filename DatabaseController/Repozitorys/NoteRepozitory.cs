using System;
using System.Collections.Generic;
using System.Linq;
using CommonInformation;
using DatabaseController.Models;

namespace DatabaseController.Repozitorys
{
    public static class NoteRepozitory
    {

        public static IEnumerable<Note> GetAll()
        {
            var connection = SingltoneConnection.GetInstance();
            var result = connection.Table<Note>().ToList();
            return result;  
        }
        public static Note Get(int id)
        {
            if (id < 0)
            {
                throw new Exception(LanguageDictionary.GetValue("GetNoteOperationInputError"));
            }
            var connection = SingltoneConnection.GetInstance();
            var res = connection.Table<Note>().FirstOrDefault(o=>o.Id==2);
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
            
            var result = connection.Insert(newNote);
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
            var rows = connection.Delete<Note>(id);

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
            var result = connection.Update(note, typeof(Note));
            if (result == 0)
            {
                throw new Exception(LanguageDictionary.GetValue("UpdateNoteOperationUnknownError"));
            }
        }
    }
}
