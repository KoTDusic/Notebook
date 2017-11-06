using System.Windows;
using System.Windows.Input;
using CommonInformation;

namespace Notebook
{
    public static class WindowCommands
    {
        public static ICommand MoveToTopCommand { get; }= new RelayCommand(MoveToTopExecute);
        public static ICommand MinimizeWindowCommand { get; } = new RelayCommand(MinimizeWindowExecute);
        public static ICommand CloseApplicationCommand { get; } = new RelayCommand(CloseApplicationExecute);

        private static void MoveToTopExecute(object obj)
        {
            var window = obj as Window;
            if (window == null)
            {
                return;
            }
            window.Visibility = Visibility.Visible;
            window.Activate();
        }
        private static void MinimizeWindowExecute(object obj)
        {
            var window = obj as Window;
            if (window == null)
            {
                return;
            }
            window.Visibility = Visibility.Collapsed;
        }
        private static void CloseApplicationExecute(object obj)
        {
            Application.Current.Shutdown();
        }
    }
}
