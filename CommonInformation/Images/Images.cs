using System;

namespace CommonInformation
{
    public static class Images
    {
        public static string LeftArrowKey = "pack://application:,,,/CommonInformation;component/Images/left_arrow.png";
        public static Uri LeftArrowImage = new Uri(LeftArrowKey, UriKind.Absolute);

        public static string TrayIconKey = "pack://application:,,,/CommonInformation;component/Images/Book.ico";
        public static Uri TrayIconImage = new Uri(TrayIconKey, UriKind.Absolute);
    }
}
