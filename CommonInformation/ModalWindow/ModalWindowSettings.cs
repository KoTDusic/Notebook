using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CommonInformation.ModalWindow
{
    public class ModalWindowSettings
    {
        public ResizeMode ResizeMode { get; set; }
        public int MinWidth { get; set; }
        public int MinHeight { get; set; }
        public int MaxWidth { get; set; }
        public int MaxHeight { get; set; }
        public string Title { get; set; }
        public ImageSource Icon { get; set; }= new BitmapImage(Images.FolderImage);
    }
}
