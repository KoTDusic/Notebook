using System.Windows;

namespace CommonInformation
{
    public enum ControlLocation
    {
        Left,
        Center,
        Right
    }
    public class ModalWindowControl
    {
        public FrameworkElement Item { get; set; }
        public ControlLocation Location { get; set; }
    }
}
