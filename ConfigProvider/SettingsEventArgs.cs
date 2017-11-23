using ConfigProvider;

namespace ConfigProvider
{
    public class SettingsEventArgs
    {
        public Settings NewSettings { get; }

        public SettingsEventArgs(Settings settings)
        {
            NewSettings = settings;
        }
    }
}
