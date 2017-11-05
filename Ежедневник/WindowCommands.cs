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
        public static ICommand AddNewNoteCommand { get; } = new RelayCommand(o=>AddNewNoteExecute());

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
        private static void AddNewNoteExecute()
        {
            var viewModel = new AddEditNoteViewModel();
            var view = new AddEditNoteView(viewModel);
            view.WindowSettings.Title = LanguageDictionary.GetValue("AddNote");
            ModalWindowPresenter.ShowModalOkCancel(view);
        }
    }
}
