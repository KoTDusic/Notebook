using System;

namespace CommonInformation.Models
{
    public class Note
    {
        public static string DataFormat { get; } = "dd.MM.yyyy";
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public bool IsArchived { get; set; }
    }
}
