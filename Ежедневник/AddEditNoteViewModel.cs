﻿using CommonInformation;
using DatabaseController.Models;

namespace Notebook
{
    public class AddEditNoteViewModel :BaseNotifcationObject
    {
        private Note _note = new Note();
        public Note Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = value; 
                OnPropertyChanged();
            }
        }
    }
}
