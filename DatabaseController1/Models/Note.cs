using System;

namespace DatabaseController.Models
{
    public enum NotePriority
    {
        Low = 3,
        Medium = 2,
        Hight = 1
    }
    public class Note : BaseNotifcationObject
    {
        private int _id;
        private DateTime _date;
        private string _message;
        private NotePriority _priority;
        private bool _isArchived;
        public static string DataFormat { get; } = "dd.MM.yyyy";

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public NotePriority Priority
        {
            get
            {
                return _priority; 
            }
            set
            {
                _priority = value;
                OnPropertyChanged();
            }
        }

        public bool IsArchived
        {
            get
            {
                return _isArchived; 
            }
            set
            {
                _isArchived = value;
                OnPropertyChanged();
            }
        }

        public Note()
        {
            _date = DateTime.Now;
            _priority = NotePriority.Medium;
            _isArchived = false;
        }

        public Note Clone()
        {
            return new Note
            {
                Date = Date,
                Id = Id,
                Message = Message,
                IsArchived = IsArchived,
                Priority = Priority
            };
        }
    }
}
