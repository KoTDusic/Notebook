using System;
using System.Runtime.Serialization;

namespace ConfigProvider
{
    [DataContract(Name = "Settings")]
    public class Settings
    {
        [DataMember(Name = "backup_path")]
        public string BackupPath { get; set; }
        [DataMember(Name = "database_path")]
        public string DatabasePath { get; set; }

        public Settings Clone()
        {
            return new Settings
            {
                BackupPath = BackupPath,
                DatabasePath = DatabasePath
            };
        }
    }
}
