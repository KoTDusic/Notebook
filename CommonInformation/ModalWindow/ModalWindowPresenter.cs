using System.Windows;

namespace CommonInformation
{
    public static class ModalWindowPresenter
    {
        public static bool? ShowModal(FrameworkElement view, params ModalWindowControl[] items)
        {
            var wnd = new CommonModalWindow(view, items);
            return wnd.ShowDialog();
        }
    }
}
