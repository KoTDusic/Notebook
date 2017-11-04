using System.Windows;
using System.Windows.Input;
using CommonInformation;
using Ежедневник.AddNoteView;

namespace Notebook
{
    public static class WindowCommands
    {
        public static ICommand MoveToTopCommand { get; }= new RelayCommand(MoveToTopExecute);
        public static ICommand MinimizeWindowCommand { get; } = new RelayCommand(MinimizeWindowExecute);
        public static ICommand CloseApplicationCommand { get; } = new RelayCommand(CloseApplicationExecute);
        public static ICommand AddNewNoteCommand { get; private set; } = new RelayCommand(o=>AddNewNoteExecute());

        private static void MoveToTopExecute(object obj)
        {
            var window = obj as Window;
            if (window == null)
            {
                return;
            }
            window.WindowState = WindowState.Normal;
            window.Activate();
        }
        private static void MinimizeWindowExecute(object obj)
        {
            var window = obj as Window;
            if (window == null)
            {
                return;
            }
            window.WindowState = WindowState.Minimized;
        }
        private static void CloseApplicationExecute(object obj)
        {
            Application.Current.Shutdown();
        }
        private static void AddNewNoteExecute()
        {
            var viewModel = new AddNoteViewModel();
            var view = new AddNoteView(viewModel);
            ModalWindowPresenter.ShowModal(view, 
            ControlsCreator.GetOkButton(viewModel.CreateNoteCommand), ControlsCreator.GetCancelButton());
        }
    }
}
