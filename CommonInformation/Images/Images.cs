﻿using System;

namespace CommonInformation
{
    public static class Images
    {
        public static string LeftArrowKey = "pack://application:,,,/CommonInformation;component/Images/left_arrow.png";
        public static Uri LeftArrowImage = new Uri(LeftArrowKey, UriKind.Absolute);

        public static string TrayIconKey = "pack://application:,,,/CommonInformation;component/Images/tray_icon.ico";
        public static Uri TrayIconImage = new Uri(TrayIconKey, UriKind.Absolute);

        public static string ArchiveImageKey = "pack://application:,,,/CommonInformation;component/Images/archive.png";
        public static Uri ArchiveImage = new Uri(ArchiveImageKey, UriKind.Absolute);

        public static string ArchiveActivatedImageKey = "pack://application:,,,/CommonInformation;component/Images/archive_activated.png";
        public static Uri ArchiveActivatedImage = new Uri(ArchiveActivatedImageKey, UriKind.Absolute);
    }
}
