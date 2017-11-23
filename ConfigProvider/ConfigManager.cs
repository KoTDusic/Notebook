using System;
using System.IO;
using System.Runtime.Serialization;

namespace ConfigProvider
{
    public static class ConfigManager
    {
        private static string SettingsFileName { get; } = "settings.xml";
        private static readonly DataContractSerializer Serializer = new DataContractSerializer(typeof(Settings));

        public static bool SaveData(Settings settings)
        {
            try
            {
                using (var writer = new FileStream(SettingsFileName, FileMode.OpenOrCreate))
                {
                    Serializer.WriteObject(writer, settings);
                    OnSettingsChanged(new SettingsEventArgs(settings));
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Settings LoadData()
        {
            Settings result;
            using (var reader = new FileStream(SettingsFileName, FileMode.OpenOrCreate))
            {
                try
                {
                    result = (Settings) Serializer.ReadObject(reader);
                }
                catch (Exception)
                {
                    result = new Settings();
                }
            }
            var needFileRepair = false;
            if (string.IsNullOrEmpty(result.BackupPath))
            {
                needFileRepair = true;
                result.BackupPath = Directory.GetCurrentDirectory();
            }
            if (string.IsNullOrEmpty(result.DatabasePath))
            {
                needFileRepair = true;
                result.DatabasePath = Directory.GetCurrentDirectory();
            }
            if (!needFileRepair)
            {
                return result;
            }
            return SaveData(result) ? result : null;
        }

        public delegate void SettingsChangedDelegate(SettingsEventArgs args);

        public static event SettingsChangedDelegate SettingsChanged;

        private static void OnSettingsChanged(SettingsEventArgs args)
        {
            SettingsChanged?.Invoke(args);
        }
    }

    
}

